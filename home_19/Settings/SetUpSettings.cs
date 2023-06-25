using System.Xml;
using System.Xml.Serialization;

namespace home_19.Settings
{
    public class SetUpSettings
    {
        protected string baseURL;
        protected string token;

        public SetUpSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RunSettings));
            using (XmlReader reader = XmlReader.Create($"{Environment.CurrentDirectory}\\settings.xml"))
            {
                RunSettings settings = (RunSettings)serializer.Deserialize(reader);
                baseURL = settings.TestRunParameters.Parameter.Where(parameter => parameter.Name == "baseURL").First().Value;
                token = settings.TestRunParameters.Parameter.Where(parameter => parameter.Name == "token").First().Value;
            }
        }
    }
}
