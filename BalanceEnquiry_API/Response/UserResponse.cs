using BalanceEnquiry_API.Models;

namespace BalanceEnquiry_API.Response
{
    public class UserResponse
    {

        public string retval { get; set; }
        public string message { get; set; }
        public Balance BalanceDetails { get; set; }
    }
}
