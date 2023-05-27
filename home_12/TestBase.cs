using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace home_12
{
    public class TestBase
    {
        protected WebDriver driver = new FirefoxDriver();

        [SetUp]
        public void SetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        }

        protected void WaitElement(By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(element => element.FindElement(by));
        }

        protected void WaitElementWithTitle(By by, string text)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(element => element.FindElement(by).Text.ToLower() == text.ToLower());
        }

        protected void WaitElements(By by, int count)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(element => element.FindElements(by).Count == count);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
