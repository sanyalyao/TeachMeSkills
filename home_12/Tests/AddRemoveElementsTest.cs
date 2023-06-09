﻿using NUnit.Framework;
using OpenQA.Selenium;
using home_12.Helpers;

namespace home_12.Tests
{
    class AddRemoveElementsTest : TestBase
    {
        [Test]
        [Description("Add/Remove Elements - добавить 2 элемента, удалить элемент, проверить количество элементов")]
        public void AddRemove()
        {
            driver.FindElement(By.LinkText("Add/Remove Elements")).Click();

            WaitHelper.WaitElement(driver, By.CssSelector("button[onclick='addElement()']"));

            driver.FindElement(By.CssSelector("button[onclick='addElement()']")).Click();
            driver.FindElement(By.CssSelector("button[onclick='addElement()']")).Click();

            WaitHelper.WaitElement(driver, By.ClassName("added-manually"), 2);

            driver.FindElement(By.ClassName("added-manually")).Click();

            Assert.AreEqual(driver.FindElements(By.ClassName("added-manually")).Count, 1);
        }
    }
}
