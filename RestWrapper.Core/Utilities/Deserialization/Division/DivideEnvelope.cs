using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Division
{
    [XmlRoot(ElementName = "Envelope")]
    public class DivideEnvelope
    {

        [XmlElement(ElementName = "Body")]
        public DivideBody Body { get; set; }
    }
}
