using System.Data.Entity.Migrations;

using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MobiStoreDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MobiStoreDbContext context)
        {
        }
    }
}
