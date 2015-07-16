using System.Data.Entity.Migrations;
using MVC5.DataLayer.Context;

namespace MVC5.DataLayer.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
