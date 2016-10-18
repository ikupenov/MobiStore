using System;

using MobiStore.Data.Contracts;
using MobiStore.Utils.Contracts;

namespace MobiStore.Utils.Importers
{
    public class XmlImporter<T> : IXmlImporter<T> where T : class
    {
        private IRepository<T> repository;

        public XmlImporter(IRepository<T> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(
                    $"{this.GetType().Name} constructor parameter {repository.GetType().Name} cannot be null.");
            }

            this.repository = repository;
        }

        public void Import(T fileToImport)
        {
            this.repository.Add(fileToImport);
        }
    }
}