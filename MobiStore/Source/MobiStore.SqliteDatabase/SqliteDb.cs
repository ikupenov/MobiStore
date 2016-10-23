using System.Data.Entity;

using MobiStore.SqliteDatabase.Models;
using SQLite.CodeFirst;

namespace MobiStore.SqliteDatabase
{
    public class SqliteDb : DbContext
    {
        public SqliteDb()
            : base("Stores")
        {
        }

        public IDbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<SqliteDb>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}