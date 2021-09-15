using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Addition
{
    [XmlRoot(ElementName = "Envelope")]
    public class AddEnvelope
    {

        [XmlElement(ElementName = "Body")]
        public AddBody Body { get; set; }
    }
}
