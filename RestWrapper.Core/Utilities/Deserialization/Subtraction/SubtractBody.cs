using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Subtraction
{
    [XmlRoot(ElementName = "Body")]
    public class SubtractBody
    {

        [XmlElement(ElementName = "SubtractResponse")]
        public SubtractResponse SubtractResponse { get; set; }
    }
}