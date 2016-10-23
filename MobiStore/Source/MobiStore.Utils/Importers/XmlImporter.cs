using System;
using System.IO;
using System.Xml.Serialization;

using MobiStore.Data.Contracts;
using MobiStore.Utilities.Contracts;

using MongoDB.Driver;

namespace MobiStore.Utilities.Importers
{
    public abstract class XmlImporter : IXmlImporter
    {
        private const string NullExceptionMessage = "The provided parameter [{0}] in {1}'s constructor cannot be null.";

        private ISqlServerDb sqlServerDatabase;
        private IMongoDatabase mongoDatabase;
        private XmlSerializer xmlSerializer;

        protected XmlImporter(ISqlServerDb sqlServerDatabase, IMongoDatabase mongoData, XmlSerializer xmlSerializer)
        {
            this.SqlServerDatabase = sqlServerDatabase;
            this.MongoDatabase = mongoData;
            this.XmlSerializer = xmlSerializer;
        }

        protected ISqlServerDb SqlServerDatabase
        {
            get
            {
                return this.sqlServerDatabase;
            }

            private set
            {
                if (value == null)
                {
                    var exceptionMessage = string.Format(NullExceptionMessage, this.sqlServerDatabase.GetType().Name, this.GetType().Name);
                    throw new ArgumentNullException(exceptionMessage);
                }

                this.sqlServerDatabase = value;
            }
        }

        protected IMongoDatabase MongoDatabase
        {
            get
            {
                return this.mongoDatabase;
            }

            private set
            {
                if (value == null)
                {
                    var exceptionMessage = string.Format(NullExceptionMessage, this.mongoDatabase.GetType().Name, this.GetType().Name);
                    throw new ArgumentNullException(exceptionMessage);
                }

                this.mongoDatabase = value;
            }
        }

        protected XmlSerializer XmlSerializer
        {
            get
            {
                return this.xmlSerializer;
            }

            private set
            {
                if (value == null)
                {
                    var exceptionMessage = string.Format(NullExceptionMessage, this.xmlSerializer.GetType().Name, this.GetType().Name);
                    throw new ArgumentNullException(exceptionMessage);
                }

                this.xmlSerializer = value;
            }
        }

        public abstract void Import(DirectoryInfo xmlFilePath);
    }
}