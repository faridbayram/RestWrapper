using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Addition
{
    [XmlRoot(ElementName = "Body")]
    public class AddBody
    {

        [XmlElement(ElementName = "AddResponse")]
        public AddResponse AddResponse { get; set; }
    }
}