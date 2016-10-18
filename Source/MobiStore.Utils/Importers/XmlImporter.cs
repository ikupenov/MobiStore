using System;

using MobiStore.Data.Contracts;
using MobiStore.Utils.Contracts;

namespace MobiStore.Utils.Importers
{
    public class XmlImporter<T> : IXmlImporter<T> where T : class
    {
        private const string NullRepositoryMessage = "{0} constructor parameter {1} cannot be null.";

        private IRepository<T> repository;

        public XmlImporter(IRepository<T> repository)
        {
            if (repository == null)
            {
                string exceptionMessage = string.Format(NullRepositoryMessage, this.GetType().Name, repository.GetType().Name);
                throw new ArgumentNullException(exceptionMessage);
            }

            this.repository = repository;
        }

        public void Import(T fileToImport)
        {
            this.repository.Add(fileToImport);
        }
    }
}