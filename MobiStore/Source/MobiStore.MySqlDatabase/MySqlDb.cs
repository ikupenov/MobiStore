using MobiStore.MySqlDatabase.Contracts;
using MobiStore.MySqlDatabase.Models;
using MobiStore.MySqlDatabase.Repositories;

namespace MobiStore.MySqlDatabase
{
    public class MySqlDb
    {
        private const string ConnectionString = "server=localhost;database=mobistore;uid=root;pwd={0};";

        private readonly MySqlContext context;

        public MySqlDb()
        {
            var password = this.MySqlPasswordPrompt();
            this.context = new MySqlContext(string.Format(ConnectionString, password));

            this.SalesRepository = new MySqlRepository<SalesReport>(this.context);

            this.VerifyDatabase();
        }

        public IMySqlRepository<SalesReport> SalesRepository { get; private set; }

        private void VerifyDatabase()
        {
            var schemaHandler = this.context.GetSchemaHandler();

            string script;

            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }

        private string MySqlPasswordPrompt()
        {
            // Enter your MySql 'root' password
            var password = "6567";

            return password;
        }
    }
}