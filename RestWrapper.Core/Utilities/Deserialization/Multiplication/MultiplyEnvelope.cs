using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Multiplication
{
    [XmlRoot(ElementName = "Envelope")]
    public class MultiplyEnvelope
    {

        [XmlElement(ElementName = "Body")]
        public MultiplyBody Body { get; set; }
    }
}
