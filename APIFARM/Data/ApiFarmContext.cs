using APIFARM.Models;
using Microsoft.EntityFrameworkCore;
namespace APIFARM.Data
{
    public class ApiFarmContext :DbContext
    {
        public ApiFarmContext(DbContextOptions<ApiFarmContext> options) : base(options) { }

        public DbSet<Salarie> Salaries { get; set; }

        public DbSet<Site> Sites { get; set; }
        public DbSet<Service> Services { get; set; }

    }
}
