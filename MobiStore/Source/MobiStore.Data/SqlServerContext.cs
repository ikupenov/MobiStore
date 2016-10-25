using System.Data.Entity;

using MobiStore.Data.Contracts;
using MobiStore.Models;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;
using MobiStore.Models.Reports;

namespace MobiStore.Data
{
    public class SqlServerContext : DbContext, ISqlServerContext
    {
        public SqlServerContext()
            : base("MobiStore")
        {
        }

        public virtual DbSet<Battery> Batteries { get; set; }

        public virtual DbSet<Display> Displays { get; set; }

        public virtual DbSet<Processor> Processors { get; set; }

        public virtual DbSet<MobileDevice> MobileDevices { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Shop> Shops { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<SalesReport> SalesReports { get; set; }

        public static SqlServerContext Create()
        {
            SqlServerContext instance = new SqlServerContext();
            return instance;
        }

        DbSet<T> ISqlServerContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}