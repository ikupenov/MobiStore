using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Data.Contracts
{
    public interface ISqlServerContext
    {
        DbSet<Battery> Batteries { get; set; }

        DbSet<Display> Displays { get; set; }

        DbSet<Processor> Processors { get; set; }

        DbSet<MobileDevice> MobileDevices { get; set; }

        DbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void Dispose();

        int SaveChanges();
    }
}
