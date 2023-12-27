using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> opts) : base(opts) { }
        
        public DbSet<Customer> Customers { get; set; }
    }

}
