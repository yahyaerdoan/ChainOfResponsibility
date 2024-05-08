using Microsoft.EntityFrameworkCore;

namespace ChainofResponsibilityUserInteface.ChainOfRes.DataAccessLayer.Context
{
    public class ChainOfRespDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YAHYAERDOGAN; initial catalog=ChainOfRespDb; integrated security=true;");
        }

        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}