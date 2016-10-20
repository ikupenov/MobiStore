using System;
using System.IO;
using System.Xml.Serialization;

using MobiStore.Data.Contracts;
using MobiStore.Models;
using MobiStore.Utils.Contracts;

namespace MobiStore.Utils.Importers
{
    public class XmlImporter : IXmlImporter
    {
        private const string NullExceptionMessage = "The provided parameter [{0}] in {1}'s constructor cannot be null.";

        private IMobiStoreData mobiStoreData;
        private XmlSerializer serializer;

        public XmlImporter(IMobiStoreData mobiStoreData, XmlSerializer serializer)
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

            this.mobiStoreData = mobiStoreData;
            this.serializer = serializer;
        }

        public void Import(string xmlFilePath)
        {
            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                var shop = (Shop)this.serializer.Deserialize(fileStream);

                foreach (var mobileDevice in shop.MobileDevices)
                {
                    Console.WriteLine(mobileDevice.Brand);
                    this.mobiStoreData.MobileDevices.Add(mobileDevice);
                }

                this.mobiStoreData.SaveChanges();
            }
        }
    }
}