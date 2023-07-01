using System.Xml.Serialization;

namespace home_19.Settings
{

    [XmlRoot(ElementName = "RunSettings")]
    public class RunSettings
    {

        [XmlElement(ElementName = "TestRunParameters")]
        public TestRunParameters TestRunParameters { get; set; }
    }
}
