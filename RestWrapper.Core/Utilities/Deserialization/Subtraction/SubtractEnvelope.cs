using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Subtraction
{
    [XmlRoot(ElementName = "Envelope")]
    public class SubtractEnvelope
    {

        [XmlElement(ElementName = "Body")]
        public SubtractBody Body { get; set; }
    }
}
