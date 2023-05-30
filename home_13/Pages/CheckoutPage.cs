using OpenQA.Selenium;
using home_13.Models;
using System.Collections.Generic;
using home_13.Helpers;

namespace home_13.Pages
{
    class CheckoutPage : BasePage
    {
        private By firstNameInput = By.Id("first-name");
        private By lastNameInput = By.Id("last-name");
        private By zipCodeInput = By.Id("postal-code");
        private By continueButton = By.Id("continue");
        private By cartList = By.ClassName("cart_list");
        private By itemName = By.ClassName("inventory_item_name");
        private By itemDescription = By.ClassName("inventory_item_desc");
        private By itemPrice = By.ClassName("inventory_item_price");
        private By totalPrice = By.CssSelector("div[class='summary_info_label summary_total_label']");
        private By tax = By.ClassName("summary_tax_label");
        private By finishButton = By.Id("finish");
        protected By completeHeader = By.ClassName("complete-header");

        public CheckoutPage(WebDriver driver) : base(driver) { }

        public CheckoutPage FillUpForm(CustomerModel customer)
        {
            driver.FindElement(firstNameInput).SendKeys(customer.FirstName);
            driver.FindElement(lastNameInput).SendKeys(customer.LastName);
            driver.FindElement(zipCodeInput).SendKeys(customer.ZipCode);
            return this;
        }

        public void ClickContinueButton()
        {
            driver.FindElement(continueButton).Click();
            WaitHelper.WaitElement(driver, totalPrice);
        }

        public double GetTotalPrice()
        {
            return double.Parse(driver.FindElement(totalPrice).Text.Split('$')[1]);
        }

        public double GetTax()
        {
            return double.Parse(driver.FindElement(tax).Text.Split('$')[1]);
        }

        public void ClickFinishButton()
        {
            driver.FindElement(finishButton).Click();
            WaitHelper.WaitElement(driver, completeHeader);
        }

        public string GetFinishTitle()
        {
            return driver.FindElement(completeHeader).Text;
        }

        public List<ProductModel> GetItemsFromOverview()
        {
            List<ProductModel> listOfProducts = new List<ProductModel>();

            foreach (IWebElement item in GetIWebElements())
            {
                string name = item.FindElement(itemName).Text;
                string description = item.FindElement(itemDescription).Text;
                double price = double.Parse(item.FindElement(itemPrice).Text.Split('$')[1]);

                listOfProducts.Add(new ProductModel(name, description, price));
            }

            return listOfProducts;
        }

        private IReadOnlyCollection<IWebElement> GetIWebElements()
        {
            return driver.FindElement(cartList).FindElements(By.ClassName("cart_item"));
        }
    }
}
