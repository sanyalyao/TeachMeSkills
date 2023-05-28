using NUnit.Framework;
using OpenQA.Selenium;
using home_12.Helpers;

namespace home_12.Tests
{
    class CheckboxesTest : TestBase
    {
        [Test]
        [Description("Checkboxes - проверить, что первый чекбокс unchecked, отметить первый чекбокс, проверить что он checked.Проверить, что второй чекбокс checked, сделать unheck, проверить, что он unchecked")]
        public void Checkboxes()
        {
            driver.FindElement(By.LinkText("Checkboxes")).Click();

            WaitHelper.WaitElementWithTitle(driver, By.TagName("h3"), "Checkboxes");

            IWebElement firstCheckbox = driver.FindElements(By.CssSelector("input[type='checkbox']"))[0];
            IWebElement secondCheckbox = driver.FindElements(By.CssSelector("input[type='checkbox']"))[1];

            Assert.IsFalse(firstCheckbox.Selected);

            firstCheckbox.Click();

            Assert.IsTrue(firstCheckbox.Selected);
            Assert.IsTrue(secondCheckbox.Selected);

            secondCheckbox.Click();

            Assert.IsFalse(secondCheckbox.Selected);
        }
    }
}
