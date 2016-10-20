using System;
using System.Linq;
using System.Xml.Linq;

using MobiStore.Models.MobileDevices.Components;

namespace MobiStore.Utils.Readers
{
    public class XmlReader
    {
        private const string TemporaryUrl = @"C:\Users\Ilian\Documents\Telerik\Telerik Projects\Database\MobiStore\MobiStore\Data\Models\phone.xml";

        public static void Parse()
        {
            var xDoc = new XDocument(TemporaryUrl);

            xDoc.Descendants()
                .Where(x => x.Name == "type" && x.Name == "capacity" && x.Parent.Name == "battery")
                .ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}