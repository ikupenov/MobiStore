using MobiStore.Models;
using MobiStore.Models.Common;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;
using MobiStore.Models.Reports;

namespace MobiStore.Data.Contracts
{
    public interface IMobiStoreData
    {
        IRepository<Battery> Batteries { get; }

        IRepository<Display> Displays { get; }

        IRepository<Processor> Processors { get; }

        IRepository<MobileDevice> MobileDevices { get; }

        IRepository<Country> Countries { get; }

        IRepository<Shop> Shops { get; }

        IRepository<Employee> Employees { get; }

        IRepository<Sale> Sales { get; }

        IRepository<SalesReport> SalesReports { get; }

        void SaveChanges();

        void Dispose();
    }
}