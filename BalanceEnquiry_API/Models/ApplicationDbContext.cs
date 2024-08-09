using Microsoft.EntityFrameworkCore;

namespace BalanceEnquiry_API.Models
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PrimePayroll;user id=sa;password=12345;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }



        public DbSet<Balance> Balances { get; set; }
        public DbSet<Customer> Customers { get; set; }



    }







}
