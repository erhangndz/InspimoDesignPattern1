using Microsoft.EntityFrameworkCore;

namespace InspimoDesignPattern1.DAL
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ERHAN\\SQLEXPRESS;database=DbInspimoDp1;integrated security=true");
        }

        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
