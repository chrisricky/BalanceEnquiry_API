using BalanceEnquiry_API.Models;


namespace BalanceEnquiry_API.Response
{
    public class UserResponse2
    {
        public string retval { get; set; }
        public string message { get; set; }
        public Customer CustomerDetails { get; set; }
    }
}
