using home_19.Core;
using home_19.Settings;
using NUnit.Framework;


namespace home_19.Tests
{
    public class BaseApiTest : SetUpSettings
    {
        protected BaseAPIClient apiClient;

        [OneTimeSetUp]
        public void Initial()
        {
            apiClient = new BaseAPIClient(baseURL);
            apiClient.AddToken(token);
        }
    }
}
