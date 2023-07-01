﻿using Diploma.Elements;
using Diploma.Models;
using Diploma.Helpers;
using OpenQA.Selenium;

namespace Diploma.Pages
{
    public class LoginPage : BasePage
    {
        private const string url = "https://ozatvn2-dev-ed.develop.my.salesforce.com/";

        private By titleHomeBy = By.CssSelector("span[class='breadcrumbDetail uiOutputText']");

        private Input usernameInput = new Input("input", "name", "username");
        private Input passwordInput = new Input("input", "name", "pw");
        private Input buttonLogin = new Input("input", "name", "Login");

        public LoginPage OpenLoginPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public ProfilePage LogIn(UserModel user)
        {
            usernameInput.GetElement().SendKeys(user.Username);
            passwordInput.GetElement().SendKeys(user.Password);
            buttonLogin.GetElement().Click();

            WaitHelper.WaitElement(driver, titleHomeBy);

            return new ProfilePage().GoToProfilePage();
        }
    }
}
