using System.IO;

namespace MobiStore.Utilities.Contracts
{
    public interface IXmlImporter
    {
        void Import(DirectoryInfo xmlFilePath);
    }
}