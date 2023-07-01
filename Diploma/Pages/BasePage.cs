using OpenQA.Selenium;
using Diploma.Settings;

namespace Diploma.Pages
{
    public class BasePage
    {
        protected IWebDriver driver => BrowserSettings.Instance.Driver;
    }
}
