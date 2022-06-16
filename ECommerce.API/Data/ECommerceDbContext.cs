using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data
{
    public class ECommerceDbContext:DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options): base(options) { }
        public DbSet<Vegetable> Vegetables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-FNO20ES\\SQLEXPRESS;Initial Catalog=ECommerceDb;Integrated Security=True")
                .UseLazyLoadingProxies()
                .LogTo(Console.WriteLine, new[] {
                    DbLoggerCategory.Model.Name,
                    DbLoggerCategory.Database.Command.Name,
                    DbLoggerCategory.Database.Transaction.Name,
                    DbLoggerCategory.Query.Name,
                    DbLoggerCategory.ChangeTracking.Name,
                },
                       LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }
}
