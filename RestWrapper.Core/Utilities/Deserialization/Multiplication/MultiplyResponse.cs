using System.Xml.Serialization;

namespace RestWrapper.Core.Utilities.Deserialization.Multiplication
{
    [XmlRoot(ElementName = "MultiplyResponse")]
    public class MultiplyResponse
    {

        [XmlElement(ElementName = "MultiplyResult")]
        public int MultiplyResult { get; set; }
    }
}