namespace MobiStore.Utils.Contracts
{
    public interface IXmlImporter<T> where T : class
    {
        void Import(T fileToImport);
    }
}