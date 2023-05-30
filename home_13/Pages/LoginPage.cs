using OpenQA.Selenium;
using home_13.Models;

namespace home_13.Pages
{
    class LoginPage : BasePage
    {
        private By UserNameInput = By.Id("user-name");
        private By PasswordInput = By.Id("password");
        private By ErrorMessage = By.CssSelector("h3[data-test='error']");
        private By LoginButton = By.Id("login-button");

        public const string url = "https://www.saucedemo.com/";
        public const string standardUserName = "standard_user";
        public const string lockedOutUser = "locked_out_user";
        public const string passwordForAllUsers = "secret_sauce";

        public LoginPage(WebDriver driver) : base(driver) { }

        public LoginPage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public InventoryPage LoginAsStandardUser()
        {
            UserModel user = new UserModel()
            {
                UserName = standardUserName,
                Password = passwordForAllUsers,
            };

            TryToLogin(user);

            InventoryPage page = new InventoryPage(driver);
            page.WaitInventoryPage();

            return page;
        }

        public void LoginAsLockedOutUser()
        {
            UserModel user = new UserModel()
            {
                UserName = lockedOutUser,
                Password = passwordForAllUsers,
            };

            TryToLogin(user);
        }

        public void TryToLogin(UserModel user)
        {
            driver.FindElement(UserNameInput).SendKeys(user.UserName);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(LoginButton).Click();
        }

        public LoginPage SetUserName(string username)
        {
            driver.FindElement(UserNameInput).SendKeys(username);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            driver.FindElement(PasswordInput).SendKeys(password);
            return this;
        }

        public IWebElement GetLoginButton()
        {
            return driver.FindElement(LoginButton);
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(ErrorMessage).Text.ToLower();
        }
    }
}
