using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        // The class must expose a public constructor with a DbContextOptions<MyDbContext> parameter.
        // This is how context configuration from AddDbContext is passed to the DbContext.
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=TestDatabase1;Trusted_Connection=True");
        }
    }
}