using ABC.Entities;
using Microsoft.EntityFrameworkCore;

namespace ABC.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<Spending> Spendings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
