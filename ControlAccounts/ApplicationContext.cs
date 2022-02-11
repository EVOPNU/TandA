using Microsoft.EntityFrameworkCore;
using ControlAccounts.Models;

namespace ControlAccounts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }
        public DbSet<Account> account{ get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost:3306;user=root;password=root;database=taa;",
                new MySqlServerVersion(new Version(8, 0, 23))
            );
        }
    }
}
