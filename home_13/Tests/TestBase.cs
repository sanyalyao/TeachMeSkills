using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using System;
using home_13.Pages;

namespace home_13
{
    class TestBase
    {
        protected WebDriver driver;
        protected LoginPage LoginPage;
        protected InventoryPage InventoryPage;
        protected CartPage CartPage;
        protected CheckoutPage CheckoutPage;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPage = new LoginPage(driver);
            InventoryPage = new InventoryPage(driver);
            CartPage = new CartPage(driver);
            CheckoutPage = new CheckoutPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
