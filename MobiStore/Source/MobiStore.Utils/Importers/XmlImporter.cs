using System;
using System.Xml.Serialization;

using MobiStore.Data.Contracts;
using MobiStore.Utils.Contracts;
using MongoDB.Driver;

namespace MobiStore.Utils.Importers
{
    public abstract class XmlImporter : IXmlImporter
    {
        private const string NullExceptionMessage = "The provided parameter [{0}] in {1}'s constructor cannot be null.";

        protected XmlImporter(IMobiStoreData sqlServerData, IMongoDatabase mongoData, XmlSerializer xmlSerializer)
        {
            if (sqlServerData == null)
            {
                var exceptionMsg = string.Format(NullExceptionMessage, sqlServerData.GetType().Name, this.GetType().Name);
                throw new ArgumentNullException(exceptionMsg);
            }

            if (xmlSerializer == null)
            {
                var exceptionMsg = string.Format(NullExceptionMessage, xmlSerializer.GetType().Name, this.GetType().Name);
                throw new ArgumentNullException(exceptionMsg);
            }

            if (mongoData == null)
            {
                var exceptionMsg = string.Format(NullExceptionMessage, mongoData.GetType().Name, this.GetType().Name);
                throw new ArgumentNullException(exceptionMsg);
            }

            this.SqlServerDatabase = sqlServerData;
            this.MongoDatabase = mongoData;
            this.XmlSerializer = xmlSerializer;
        }

        protected IMobiStoreData SqlServerDatabase { get; private set; }

        protected IMongoDatabase MongoDatabase { get; private set; }

        protected XmlSerializer XmlSerializer { get; private set; }

        public abstract void Import(string xmlFilePath);
    }
}