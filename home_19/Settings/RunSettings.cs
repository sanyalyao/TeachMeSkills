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

    [XmlRoot(ElementName = "TestRunParameters")]
    public class TestRunParameters
    {

        [XmlElement(ElementName = "Parameter")]
        public List<Parameter> Parameter { get; set; }
    }

    [XmlRoot(ElementName = "RunSettings")]
    public class RunSettings
    {

        [XmlElement(ElementName = "TestRunParameters")]
        public TestRunParameters TestRunParameters { get; set; }
    }
}
