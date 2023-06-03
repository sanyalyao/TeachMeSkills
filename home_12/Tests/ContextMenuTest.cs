using NUnit.Framework;
using OpenQA.Selenium;
using home_12.Helpers;
using OpenQA.Selenium.Interactions;

namespace home_12.Tests
{
    class ContextMenuTest : TestBase
    {
        [Test]
        [Description("Context Menu " +
            "i. Правый клик по элементу " +
            "ii. Валидация текста на алерте " +
            "iii. Закрытие алерта")]
        public void CheckContextMenu()
        {
            By hotSpot = By.Id("hot-spot");

            driver.FindElement(By.LinkText("Context Menu")).Click();

            WaitHelper.WaitElement(driver, hotSpot);

            Actions action = new Actions(driver);
            IWebElement square = driver.FindElement(hotSpot);

            action.ContextClick(square).Perform();

            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;

            Assert.AreEqual("You selected a context menu", alertText);

            alert.Accept();
        }
    }
}
