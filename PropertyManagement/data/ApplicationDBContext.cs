using Microsoft.EntityFrameworkCore;
using PropertyManagement.models; 

namespace PropertyManagement.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<User> UserAdmin { get; set; } = null!;
        public DbSet<User> UserClient { get; set; } = null!;
        public DbSet<Property> Property { get; set; } = null!;
        public DbSet<Rent> Rent { get; set; } = null!;
        public DbSet<Payment> Payment { get; set; } = null!;
    }
}