using OpenQA.Selenium;

namespace home_13.Pages
{
    class LeftPanel : BasePage
    {
        private By buttonWithThreeLines = By.Id("react-burger-menu-btn");
        private By allItems = By.ClassName("inventory_sidebar_link");
        private By about = By.ClassName("about_sidebar_link");
        private By logout = By.ClassName("logout_sidebar_link");
        private By resetAppState = By.ClassName("reset_sidebar_link");

        public LeftPanel(WebDriver driver) : base(driver) { }

        private void TapThreeLinesButton()
        {
            driver.FindElement(buttonWithThreeLines).Click();
        }

        public InventoryPage OpenAllItemsPage()
        {
            TapThreeLinesButton();
            driver.FindElement(allItems).Click();
            return new InventoryPage(driver);
        }

        public LoginPage Logout()
        {
            TapThreeLinesButton();
            driver.FindElement(logout).Click();
            return new LoginPage(driver);
        }

        public void ResetAppState()
        {
            TapThreeLinesButton();
            driver.FindElement(resetAppState).Click();
        }
    }
}
