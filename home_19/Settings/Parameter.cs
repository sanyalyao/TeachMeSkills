using System.Xml.Serialization;

namespace home_19.Settings
{
    [XmlRoot(ElementName = "Parameter")]
    public class Parameter
    {

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
