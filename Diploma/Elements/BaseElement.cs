using OpenQA.Selenium;
using Diploma.Settings;
using Diploma.Helpers;

namespace Diploma.Elements
{
    public class BaseElement
    {
        protected By locator;
        protected IWebDriver driver => BrowserSettings.Instance.Driver;

        public BaseElement(By locator)
        {
            this.locator = locator;
        }

        public BaseElement(string cssSelector)
        {
            locator = By.CssSelector(cssSelector);
        }

        public IWebElement GetElement()
        {
            WaitHelper.WaitElement(driver, locator);

            return driver.FindElement(locator);
        }
    }
}
