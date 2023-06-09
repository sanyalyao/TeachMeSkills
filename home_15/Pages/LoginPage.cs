﻿using home_15.Elements;
using home_15.Models;
using home_15.Helpers;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;

namespace home_15.Pages
{
    public class LoginPage : BasePage
    {
        private const string url = "https://ozatvn2-dev-ed.develop.my.salesforce.com/";

        private By titleHomeBy = By.CssSelector("span[class='breadcrumbDetail uiOutputText']");

        private Input usernameInput = new Input("input", "name", "username");
        private Input passwordInput = new Input("input", "name", "pw");
        private Input buttonLogin = new Input("input", "name", "Login");

        [AllureStep]
        public LoginPage OpenLoginPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        [AllureStep]
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
