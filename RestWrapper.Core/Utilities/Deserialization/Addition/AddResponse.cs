using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Addition
{
    [XmlRoot(ElementName = "AddResponse")]
    public class AddResponse
    {

        [XmlElement(ElementName = "AddResult")]
        public int AddResult { get; set; }
    }
}