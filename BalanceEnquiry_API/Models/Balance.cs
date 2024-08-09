using Microsoft.EntityFrameworkCore;

namespace BalanceEnquiry_API.Models
{
    [Keyless]
    public class Balance
    {
        public string FullName { get; set; }
        public decimal UsableBalance { get; set; }
        public decimal BookBalance { get; set; }
    }
}
