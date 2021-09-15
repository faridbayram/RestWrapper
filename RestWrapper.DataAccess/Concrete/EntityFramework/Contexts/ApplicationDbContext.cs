using Microsoft.EntityFrameworkCore;
using RestWrapper.DataAccess.Concrete.EntityFramework.Configurations;
using RestWrapper.Entities.Concrete;

namespace RestWrapper.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        /*private string connString = "Data Source =(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=10.0.6.34)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=AQTIS1.afsa.gov.az)));User Id = RP; Password=r3425HGT$$ndmmdP;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(connString);
        }*/
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CallEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RequestEntityConfiguration());
        }

        public DbSet<CallDAO> Calls { get; set; }
        public DbSet<RequestDAO> Requests { get; set; }
    }
}
