using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using MobiStore.Models.Common;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Data.Contracts
{
    public interface IMobiStoreDbContext
    {
        IDbSet<Country> Countries { get; set; }

        IDbSet<Battery> Batteries { get; set; }

        IDbSet<Display> Displays { get; set; }

        IDbSet<Processor> Processors { get; set; }

        IDbSet<MobileDevice> MobileDevices { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void Dispose();

        int SaveChanges();
    }
}
