using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BalanceEnquiry_API.Models
{
    public class Customer
    {
        [Key]
        public long CustomerId { get; set; }
        public string? Fullname { get; set; }
        public string? CustomerType { get; set; }
        public DateTime DOB { get; set; }
        [JsonProperty("Gender")]
        [Display(Name = "Gender")]
        public string? sex { get; set; }
        public string? Nationality { get; set; }
        public string? Address { get; set; }
        public string? Phone1 { get; set; }
        public string? phone2 { get; set; }
        public string? Email { get; set; }
        public string? Rcno { get; set; }
        public string? BVN { get; set; }
        public string? branchcode { get; set; }
    }
}
