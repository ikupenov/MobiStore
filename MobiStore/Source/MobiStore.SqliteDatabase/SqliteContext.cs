using System.Data.Entity;

using MobiStore.SqliteDatabase.Models;
using SQLite.CodeFirst;

namespace MobiStore.SqliteDatabase
{
    public class SqliteContext : DbContext
    {
        public SqliteContext()
            : base("Stores")
        {
        }

        public DbSet<Shop> Shops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<SqliteContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}