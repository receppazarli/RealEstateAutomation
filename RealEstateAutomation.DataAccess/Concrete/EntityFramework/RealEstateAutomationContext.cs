using System.Data.Entity;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.DataAccess.Concrete.EntityFramework
{
    public class RealEstateAutomationContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAuthorization> UserAuthorizations { get; set; }

    }
}