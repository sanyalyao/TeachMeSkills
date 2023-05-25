using NUnit.Framework;
using OpenQA.Selenium;

namespace home_12.Tests
{
    class TyposTest : TestBase
    {
        [Test]
        [Description("Typos - Проверить соответствие параграфа орфографии")]
        public void CheckTypos()
        {
            driver.FindElement(By.LinkText("Typos")).Click();

            WaitElementWithTitle(By.TagName("h3"), "Typos");

            string text = driver.FindElements(By.TagName("p"))[1].Text;
            string[] mainText = new string[] { "Sometimes", "you'll", "see", "a", "typo", "other", "times", "you", "won't" };

            foreach (string word in mainText)
            {
                Assert.IsTrue(text.Contains(word));
            }
        }
    }
}
