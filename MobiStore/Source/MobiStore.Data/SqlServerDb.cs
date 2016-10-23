using System;
using System.Collections.Generic;
using System.Data.Entity;

using MobiStore.Data.Contracts;
using MobiStore.Data.Migrations;
using MobiStore.Data.Repositories;
using MobiStore.Models;
using MobiStore.Models.Common;
using MobiStore.Models.MobileDevices;
using MobiStore.Models.MobileDevices.Components;
using MobiStore.Models.Reports;

namespace MobiStore.Data
{
    public class SqlServerDb : ISqlServerDb
    {
        private readonly ISqlServerContext context;
        private IDictionary<Type, object> repositories;

        public SqlServerDb(ISqlServerContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public SqlServerDb()
            : this(new SqlServerContext())
        {
        }
        
        public ISqlServerContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IRepository<Battery> Batteries
        {
            get
            {
                return this.GetRepository<Battery>();
            }
        }

        public IRepository<Display> Displays
        {
            get
            {
                return this.GetRepository<Display>();
            }
        }

        public IRepository<Processor> Processors
        {
            get
            {
                return this.GetRepository<Processor>();
            }
        }

        public IRepository<MobileDevice> MobileDevices
        {
            get
            {
                return this.GetRepository<MobileDevice>();
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        public IRepository<Shop> Shops
        {
            get
            {
                return this.GetRepository<Shop>(); 
            }
        }

        public IRepository<Employee> Employees
        {
            get
            {
                return this.GetRepository<Employee>(); 
            }
        }

        public IRepository<Sale> Sales
        {
            get
            {
                return this.GetRepository<Sale>(); 
            }
        }

        public IRepository<SalesReport> SalesReports
        {
            get
            {
                return this.GetRepository<SalesReport>(); 
            }
        }

        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqlServerContext, Configuration>());
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                Type type = typeof(Repository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return this.repositories[typeOfModel] as IRepository<T>;
        }
    }
}