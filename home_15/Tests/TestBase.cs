using NUnit.Framework;
using home_15.Pages;
using home_15.Settings;
using home_15.Models;

namespace home_15.Tests
{
    public class TestBase
    {
        protected LoginPage LoginPage;
        protected AccountPage AccountPage;
        protected ContactPage ContactPage;

        [SetUp]
        public void SetUp()
        {
            LoginPage = new LoginPage();
            AccountPage = new AccountPage();
            ContactPage = new ContactPage();
        }

        public void Login()
        {
            UserModel user = new UserModel("gopad74116@onlcool.com", "gerUHY456");

            LoginPage.OpenLoginPage().LogIn(user);
        }

        [TearDown]
        public void TearDown()
        {
            BrowserSettings.Instance.CloseBrowser();
        }
    }
}
