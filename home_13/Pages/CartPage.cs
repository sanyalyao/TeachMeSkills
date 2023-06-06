using home_13.Models;
using OpenQA.Selenium;
using System.Collections.Generic;
using home_13.Helpers;

namespace home_13.Pages
{
    class CartPage : BasePage
    {
        private By shoppingCartLink = By.ClassName("shopping_cart_link");
        private By checkoutButton = By.Id("checkout");
        private By cartList = By.ClassName("cart_list");
        private By itemName = By.ClassName("inventory_item_name");
        private By itemDescription = By.ClassName("inventory_item_desc");
        private By itemPrice = By.ClassName("inventory_item_price");
        private By removeButton = By.CssSelector("button[class='btn btn_secondary btn_small cart_button']");

        public CartPage(WebDriver driver) : base(driver) { }

        public CartPage OpenShoppingCart()
        {
            driver.FindElement(shoppingCartLink).Click();
            WaitHelper.WaitElement(driver, checkoutButton);
            return this;
        }

        public CheckoutPage ClickCheckoutButton()
        {
            driver.FindElement(checkoutButton).Click();
            return new CheckoutPage(driver);
        }

        public CartPage RemoveProduct(List<ProductModel> products)
        {
            foreach (ProductModel product in products)
            {
                foreach (IWebElement item in GetIWebElements())
                {
                    string name = item.FindElement(itemName).Text;

                    if (name.ToLower() == product.Name)
                    {
                        item.FindElement(removeButton).Click();
                    }
                }
            }

            return this;
        }

        public List<ProductModel> GetItemsFromCart()
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
