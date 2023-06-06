using NUnit.Framework;
using home_13.Pages;
using home_13.Models;

namespace home_13.Tests
{
    class LoginTests : TestBase
    {
        [Test]
        public void LoginStandardUser()
        {
            LoginPage.OpenPage();
            LoginPage.LoginAsStandardUser().WaitInventoryPage();
            Assert.AreEqual(driver.Url, InventoryPage.url);
        }

        [Test]
        public void FailedLogin()
        {
            UserModel user = new UserModel()
            {
                UserName = "wef",
                Password = "wef"
            };
            LoginPage.OpenPage();
            LoginPage.TryToLogin(user);
            Assert.AreEqual(LoginPage.GetErrorMessage(), "Epic sadface: Username and password do not match any user in this service".ToLower());
        }

        [Test]
        public void LoginLockedOutUser()
        {
            LoginPage.OpenPage();
            LoginPage.LoginAsLockedOutUser();
            Assert.AreEqual(LoginPage.GetErrorMessage(), "Epic sadface: Sorry, this user has been locked out.".ToLower());
        }
    }
}
