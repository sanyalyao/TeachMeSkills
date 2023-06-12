using OpenQA.Selenium;
using home_15.Settings;

namespace home_15.Pages
{
    public class BasePage
    {
        protected IWebDriver driver => BrowserSettings.Instance.Driver;
    }
}
