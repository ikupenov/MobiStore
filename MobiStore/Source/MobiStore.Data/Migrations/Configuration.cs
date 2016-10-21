using System;
using System.Data.Entity.Migrations;

using MobiStore.Models;
using MobiStore.Models.Enumerations;
using MobiStore.Models.MobileDevices;

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
            context.Employees.AddOrUpdate(
                e => e.Name,
                new Employee { Name = "Ivan", Id = Guid.Parse("dfd9f37c-8726-43ed-a512-8bec58c2ef7e") },
                new Employee { Name = "Sevda", Id = Guid.Parse("2130f5af-db0c-4320-bca7-f93b592bb070") },
                new Employee { Name = "Petur", Id = Guid.Parse("d6a76e12-cebb-4007-9714-ccc1b4947706") });

            context.MobileDevices.AddOrUpdate(
                m => m.Id,
                new MobileDevice { Model = "iPhone 6s", Brand = Brand.Apple, Id = Guid.Parse("3f86770e-59c3-4054-9681-4359158b8c50") },
                new MobileDevice { Model = "iPhone 6s", Brand = Brand.Apple, Id = Guid.Parse("320b0669-2af6-48c8-b72e-cfa1d3ecea12") },
                new MobileDevice { Model = "Desire 816", Brand = Brand.HTC, Id = Guid.Parse("73f2b815-540b-497c-b4f7-eec5516c8e5b") });

            context.Shops.AddOrUpdate(
                s => s.Name,
                new Shop { Name = "MobiStore Dragoman", Id = Guid.Parse("666c0586-072a-4291-b0ae-1141bf839ae7") },
                new Shop { Name = "MobiStore Mladost", Id = Guid.Parse("2833019e-8efc-4c6c-83ad-5121311be778") },
                new Shop { Name = "MobiStore Banishora", Id = Guid.Parse("b9e8aa80-c779-4524-9cc2-1528d599c094") });
        }
    }
}
