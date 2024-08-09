using BalanceEnquiry_API.Models;

namespace BalanceAndCustomerEnquiry_API.JWTRepository
{
    public interface IJWTRepository
    {
        Tokens Authenticate();
    }
}
