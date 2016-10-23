using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;

namespace MobiStore.MySqlDatabase
{
    public class MySqlContext : OpenAccessContext
    {
        private static readonly BackendConfiguration BackendConfig = new BackendConfiguration()
        {
            Backend = "MySql",
            ProviderName = "MySql.Data.MySqlClient"
        };

        private static readonly MetadataSource MetaDataConfig = new MySqlModelsConfig();

        public MySqlContext(string connectionString)
            : base(connectionString, BackendConfig, MetaDataConfig)
        {
        }
    }
}