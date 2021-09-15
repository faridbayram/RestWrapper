using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Division
{
    [XmlRoot(ElementName = "DivideResponse")]
    public class DivideResponse
    {

        [XmlElement(ElementName = "DivideResult")]
        public int DivideResult { get; set; }
    }
}