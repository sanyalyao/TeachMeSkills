using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace home_13.Pages
{
    class BasePage
    {
        protected WebDriver driver;

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }
    }
}
