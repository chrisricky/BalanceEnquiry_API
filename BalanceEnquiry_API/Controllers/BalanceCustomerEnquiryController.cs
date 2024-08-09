using BalanceAndCustomerEnquiry_API.JWTRepository;
using BalanceEnquiry_API.Models;
using BalanceEnquiry_API.Response;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using static System.Net.WebRequestMethods;

namespace BalanceEnquiry_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceCustomerEnquiryController : ControllerBase
    {
        private readonly IJWTRepository _jwt;
        public BalanceCustomerEnquiryController(IJWTRepository jwtrepository)
        {
            _jwt = jwtrepository;
        }

        // Repository.GetBalance getBalance = new Repository.GetBalance();
        //private readonly ApplicationDbContext _db;
        //public BalanceCustomerEnquiryController(ApplicationDbContext context)
        //{
        //    _db = context;
        //}


        [AllowAnonymous]
        [HttpGet("GenerateToken")]
        public IActionResult GenerateToken()
        {
            var token = _jwt.Authenticate();
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }


        [HttpGet("GetBalance")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<UserResponse> GetBalance(string accountnumber)
        {
           
            if (accountnumber == null)
            {
              //  return BadRequest("Input an Account Number");
                return NoContent();
            }



            bool Status = false;
            string Message = "";

            using (var _db = new ApplicationDbContext())
            {

                try
                {

                    SqlParameter retval = new SqlParameter("@retval", SqlDbType.VarChar, 4);
                    retval.Direction = System.Data.ParameterDirection.Output;

                    SqlParameter retmsg = new SqlParameter("@retmsg", SqlDbType.VarChar, 200);
                    retmsg.Direction = System.Data.ParameterDirection.Output;

                    var data = _db.Balances.FromSqlRaw<Balance>("proc_BalanceEnqiry @accountnumber,@retval out, @retmsg OUT",
                    new SqlParameter("@accountnumber", accountnumber),
                    retval, retmsg).AsEnumerable().FirstOrDefault();

                    

                    var xRetval = retval.Value.ToString();
                    string xRetMsg = retmsg.Value.ToString();
                    Message = xRetMsg;
                    Status = true;

                    if (data != null)
                    {
                        return new UserResponse { retval = xRetval, message = Message, BalanceDetails = data };
                    }
                    else
                    {
                        return new UserResponse { retval = "1", message = "Account Has No Valid Customer Record" };
                    }


                }


                catch (Exception e)
                {
                    Message = "Invalid request";
                    return Ok(e.Message);
                }

            }


           

           // return Ok();
        }



        [HttpGet("GetCustomer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserResponse2> GetCustomer(string accountnumber)
        {
            if (accountnumber == null)
            {
                return BadRequest("Input an Account Number");
            }


            bool Status = false;
            string Message = "";

            using (var _db = new ApplicationDbContext())
            {
                try
                {

                    SqlParameter retval = new SqlParameter("@retval", SqlDbType.VarChar, 4);
                    retval.Direction = System.Data.ParameterDirection.Output;

                    SqlParameter retmsg = new SqlParameter("@retmsg", SqlDbType.VarChar, 200);
                    retmsg.Direction = System.Data.ParameterDirection.Output;

                    var resp = _db.Customers.FromSqlRaw<Customer>("proc_CustEnquiryByAcctNo @accountnumber,@retval out, @retmsg OUT",
                    new SqlParameter("@accountnumber", accountnumber),
                     retval, retmsg).AsEnumerable().FirstOrDefault();



                    var xRetval = retval.Value.ToString();
                    string xRetMsg = retmsg.Value.ToString();
                    Message = xRetMsg;
                    Status = true;

                    if (resp != null)
                    {
                        return new UserResponse2 { retval = xRetval, message = Message, CustomerDetails = resp };
                    }
                    else
                    {
                        return new UserResponse2 { retval = "1", message = "Account Has No Valid Customer Record.." };
                    }


                }


                catch (Exception e)
                {
                    Message = "Invalid request";
                    return Ok(e.Message);
                }

            }


            //  return Ok();

        }


       


    }


}

