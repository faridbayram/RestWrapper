using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Multiplication
{
    [XmlRoot(ElementName = "Body")]
    public class MultiplyBody
    {

        [XmlElement(ElementName = "AddResponse")]
        public MultiplyResponse MultiplyResponse { get; set; }
    }
}