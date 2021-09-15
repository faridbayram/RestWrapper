using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Subtraction
{
    [XmlRoot(ElementName = "SubtractResponse")]
    public class SubtractResponse
    {

        [XmlElement(ElementName = "SubtractResult")]
        public int SubtractResult { get; set; }
    }
}