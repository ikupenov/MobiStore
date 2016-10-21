using System;
using System.Xml.Serialization;

using MobiStore.Data.Contracts;
using MobiStore.Utils.Contracts;

namespace MobiStore.Utils.Importers
{
    public abstract class XmlImporter : IXmlImporter
    {
        private const string NullExceptionMessage = "The provided parameter [{0}] in {1}'s constructor cannot be null.";

        protected XmlImporter(IMobiStoreData mobiStoreData, XmlSerializer serializer)
        {
            if (mobiStoreData == null)
            {
                var exceptionMsg = string.Format(NullExceptionMessage, mobiStoreData.GetType().Name, this.GetType().Name);
                throw new ArgumentNullException(exceptionMsg);
            }

            if (serializer == null)
            {
                var exceptionMsg = string.Format(NullExceptionMessage, serializer.GetType().Name, this.GetType().Name);
                throw new ArgumentNullException(exceptionMsg);
            }

            this.MobiStoreData = mobiStoreData;
            this.Serializer = serializer;
        }

        protected IMobiStoreData MobiStoreData { get; private set; }

        protected XmlSerializer Serializer { get; private set; }

        public abstract void Import(string xmlFilePath);
    }
}