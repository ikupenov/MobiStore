using System.Data.Entity;

using MobiStore.Data.Contracts;
using MobiStore.Models;
using MobiStore.Models.Common;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;
using MobiStore.Models.Reports;

namespace MobiStore.Data
{
    public class MobiStoreDbContext : DbContext, IMobiStoreDbContext
    {
        public MobiStoreDbContext()
            : base("MobiStore")
        {
        }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Battery> Batteries { get; set; }

        public virtual IDbSet<Display> Displays { get; set; }

        public virtual IDbSet<Processor> Processors { get; set; }

        public virtual IDbSet<MobileDevice> MobileDevices { get; set; }

        public virtual IDbSet<Employee> Employees { get; set; }

        public virtual IDbSet<Shop> Shops { get; set; }

        public virtual IDbSet<Sale> Sales { get; set; }

        public virtual IDbSet<SalesReport> SalesReports { get; set; }

        public static MobiStoreDbContext Create()
        {
            MobiStoreDbContext instance = new MobiStoreDbContext();
            return instance;
        }

        IDbSet<T> IMobiStoreDbContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}