using Microsoft.EntityFrameworkCore;
using PropertyManagement.models; 

namespace PropertyManagement.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<UserAdmin> Admins { get; set; } = null!;
        public DbSet<UserClient> Clients { get; set; } = null!;

        public DbSet<Property> Properties { get; set; } = null!;
        public DbSet<Rent> Rents { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
    }
}