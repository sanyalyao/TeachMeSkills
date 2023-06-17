using NUnit.Framework;
using home_15.Pages;
using home_15.Settings;
using home_15.Models;
using Allure.Net.Commons;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace home_15.Tests
{
    [AllureNUnit]
    public class TestBase
    {
        protected LoginPage LoginPage;
        protected AccountPage AccountPage;
        protected ContactPage ContactPage;
        protected AccountsPage AccountsPage;
        protected ContactsPage ContactsPage;
        protected CreationNewAccountPage CreationNewAccountPage;
        protected CreationNewContactPage CreationNewContactPage;
        protected AllureLifecycle Allure;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public void SetUp()
        {
            LoginPage = new LoginPage();
            AccountPage = new AccountPage();
            ContactPage = new ContactPage();
            AccountsPage = new AccountsPage();
            ContactsPage = new ContactsPage();
            CreationNewContactPage = new CreationNewContactPage();
            CreationNewAccountPage= new CreationNewAccountPage();
            Allure = AllureLifecycle.Instance;
        }

        public void Login()
        {
            UserModel user = new UserModel("gopad74116@onlcool.com", "gerUHY456");

            LoginPage.OpenLoginPage().LogIn(user);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)BrowserSettings.Instance.Driver).GetScreenshot();
                byte[] bytes = screenshot.AsByteArray;
                Allure.AddAttachment("ScreenShot", "image.png", bytes);
            }

            BrowserSettings.Instance.CloseBrowser();
        }
    }
}
