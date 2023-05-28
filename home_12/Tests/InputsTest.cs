using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using home_12.Helpers;

namespace home_12.Tests
{
    class InputsTest : TestBase
    {
        [Test]
        [Description("Inputs - Проверить на возможность ввести различные цифровые и нецифровые значения, используя Keys.ARROW_UP И Keys.ARROW_DOWN")]
        public void CheckInputs()
        {
            driver.FindElement(By.LinkText("Inputs")).Click();

            WaitHelper.WaitElementWithTitle(driver, By.TagName("h3"), "Inputs");

            IWebElement field = driver.FindElement(By.TagName("input"));
            Actions action = new Actions(driver);

            for (int i = 0; i < 2; i++)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                action.SendKeys(field, Keys.ArrowUp).Build().Perform();

                Assert.IsNotNull(field.Text);
            }

            for (int i = 0; i < 4; i++)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(5));

                action.SendKeys(field, Keys.ArrowDown).Build().Perform();

                Assert.IsNotNull(field.Text);
            }
        }
    }
}
