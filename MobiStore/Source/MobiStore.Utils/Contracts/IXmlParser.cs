using System.Xml.Linq;

namespace MobiStore.Utils.Contracts
{
    public interface IXmlParser
    {
        XDocument ParseToXml<T>(T elementToParse);
    }
}