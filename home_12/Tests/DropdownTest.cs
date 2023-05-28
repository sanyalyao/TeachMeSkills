using NUnit.Framework;
using OpenQA.Selenium;
using home_12.Helpers;

namespace home_12.Tests
{
    class DropdownTest : TestBase
    {
        [Test]
        [Description("Dropdown - Взять все элементы дроп-дауна и проверить их наличие. Выбрать первый, проверить, что он выбран, выбрать второй, проверить, что он выбран")]
        public void CheckDropdown()
        {
            driver.FindElement(By.LinkText("Dropdown")).Click();

            WaitHelper.WaitElementWithTitle(driver, By.TagName("h3"), "Dropdown List");

            IWebElement list = driver.FindElement(By.Id("dropdown"));

            var options = list.FindElements(By.TagName("option"));

            Assert.IsNotEmpty(options);

            options[1].Click();

            Assert.IsTrue(options[1].Selected);

            options[2].Click();

            Assert.IsTrue(options[2].Selected);
        }
    }
}
