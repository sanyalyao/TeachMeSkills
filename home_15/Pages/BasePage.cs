using OpenQA.Selenium;
using home_15.Settings;
using NLog;

namespace home_15.Pages
{
    public class BasePage
    {
        protected IWebDriver driver => BrowserSettings.Instance.Driver;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
