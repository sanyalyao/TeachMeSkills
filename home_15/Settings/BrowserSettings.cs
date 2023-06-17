using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace home_15.Settings
{
    public class BrowserSettings
    {
        private static BrowserSettings instance = null;
        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }

        public static BrowserSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BrowserSettings();
                }

                return instance;
            }
        }

        private BrowserSettings()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("dom.webnotifications.enabled", false);
            driver = new FirefoxDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            instance = null;
        }
    }
}
