﻿using System;

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
                var exceptionMessage =
                    $"{this.GetType().Name} constructor parameter {repository.GetType().Name} cannot be null";
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