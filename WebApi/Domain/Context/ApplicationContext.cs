using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<IdentityUser<int>> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> builder) : base(builder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
