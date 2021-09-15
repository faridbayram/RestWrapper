using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Division
{
    [XmlRoot(ElementName = "Body")]
    public class DivideBody
    {

        [XmlElement(ElementName = "DivideResponse")]
        public DivideResponse DivideResponse { get; set; }
    }
}