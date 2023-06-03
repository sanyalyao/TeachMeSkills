using NUnit.Framework;
using OpenQA.Selenium;
using home_12.Helpers;

namespace home_12.Tests
{
    class DynamicControlsTest : TestBase
    {
        [Test]
        [Description("Dynamic Controls " +
            "a. Найти чекбокс " +
            "b. Нажать на кнопку " +
            "c. Дождаться надписи “It’s gone” " +
            "d. Проверить, что чекбокса нет " +
            "e. Найти инпут " +
            "f. Проверить, что он disabled " +
            "g. Нажать на кнопку " +
            "h. Дождаться надписи “It's enabled!” " +
            "i. Проверить, что инпут enabled")]
        public void CheckDynamicControls()
        {
            By checkboxBy = By.Id("checkbox");
            By messageCheckbox = By.CssSelector("form[id='checkbox-example'] > p[id='message']");
            By messageInputField = By.CssSelector("form[id='input-example'] > p[id='message']");

            driver.FindElement(By.LinkText("Dynamic Controls")).Click();

            WaitHelper.WaitElement(driver, checkboxBy);

            driver.FindElement(By.CssSelector("button[onclick='swapCheckbox()']")).Click();

            WaitHelper.WaitElement(driver, messageCheckbox);

            string finalMessageCheckbox = driver.FindElement(messageCheckbox).Text;

            Assert.AreEqual("It's gone!", finalMessageCheckbox);
            Assert.IsEmpty(driver.FindElements(checkboxBy));

            IWebElement inputField = driver.FindElement(By.CssSelector("input[type='text']"));

            Assert.IsTrue(!inputField.Enabled);

            driver.FindElement(By.CssSelector("button[onclick='swapInput()']")).Click();

            WaitHelper.WaitElement(driver, messageInputField);

            string finalMessageInputField = driver.FindElement(messageInputField).Text;

            Assert.AreEqual("It's enabled!", finalMessageInputField);
            Assert.IsTrue(inputField.Enabled);
        }
    }
}
