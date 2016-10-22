using System.IO;

namespace MobiStore.Utils.Contracts
{
    public interface IXmlImporter
    {
        void Import(DirectoryInfo xmlFilePath);
    }
}