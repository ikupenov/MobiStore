using MobiStore.SqliteDatabase.Models;

namespace MobiStore.SqliteDatabase
{
    public class SqliteSeeder
    {
        public static void SeedDatabase()
        {
            var sqliteDb = new SqliteContext();

            sqliteDb.Shops.Add(new Shop { Town = "Sofia", Name = "MobiStore Mladost" });
            sqliteDb.Shops.Add(new Shop { Town = "Sofia", Name = "MobiStore Banishora" });
            sqliteDb.Shops.Add(new Shop { Town = "Sofia", Name = "MobiStore Dragoman" });

            sqliteDb.SaveChanges();
        }
    }
}