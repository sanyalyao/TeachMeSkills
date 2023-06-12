using OpenQA.Selenium;
using home_15.Settings;
using home_15.Helpers;

namespace home_15.Elements
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
