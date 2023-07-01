using System.Xml.Serialization;

namespace home_19.Settings
{
    [XmlRoot(ElementName = "TestRunParameters")]
    public class TestRunParameters
    {

        [XmlElement(ElementName = "Parameter")]
        public List<Parameter> Parameter { get; set; }
    }
}
