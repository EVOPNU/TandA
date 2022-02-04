using Microsoft.EntityFrameworkCore;
using ControlAccounts.Models;

namespace ControlAccounts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }
        public DbSet<Account> accounts{ get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=EnderWarAdmin;database=taa;",
                new MySqlServerVersion(new Version(8, 0, 27))
            );
        }
    }
}
