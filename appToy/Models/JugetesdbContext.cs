using System.Data.Entity;

namespace appToy.Models
{
    public class JugetesdbContext : DbContext
    {
        public JugetesdbContext() : base("dbJugetes")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JugetesdbContext, Migrations.Configuration>());
        }
        public DbSet<Juguete> Juguete { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}