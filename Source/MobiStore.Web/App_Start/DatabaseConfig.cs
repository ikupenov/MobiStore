using MobiStore.Data;

namespace MobiStore.Web.App_Start
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            MobiStoreData.Initialize();
            MobiStoreDbContext.Create().Database.Initialize(true);
        }
    }
}