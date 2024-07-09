using Microsoft.EntityFrameworkCore;
using OnboardCustomer.Models.Domain;

namespace OnboardCustomer.Data
{
    public class OnboardCustomerDbContext : DbContext
    {
        public OnboardCustomerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }


    }
}
