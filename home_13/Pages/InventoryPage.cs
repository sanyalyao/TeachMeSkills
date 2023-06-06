using OpenQA.Selenium;
using home_13.Helpers;
using home_13.Models;
using System.Collections.Generic;

namespace home_13.Pages
{
    class InventoryPage : BasePage
    {
        private By shoppingCartLink = By.ClassName("shopping_cart_link");
        private By productName = By.ClassName("inventory_item_name");
        private By productDescription = By.ClassName("inventory_item_desc");
        private By productPrice = By.ClassName("inventory_item_price");
        private By addToCartButton = By.CssSelector("button[class='btn btn_primary btn_small btn_inventory']");
        private By inventoryList = By.ClassName("inventory_list");

        public const string url = "https://www.saucedemo.com/inventory.html";
        public static List<ProductModel> choosenProducts = new List<ProductModel>();

        public InventoryPage(WebDriver driver) : base(driver) 
        {
        }

        public void WaitInventoryPage()
        {
            WaitHelper.WaitElement(driver, shoppingCartLink);
        }

        public CartPage AddToCart(List<ProductModel> products)
        {
            foreach (ProductModel product in products)
            {
                ClickAddToCart(product);
            }
            return new CartPage(driver);
        }

        private void ClickAddToCart(ProductModel product)
        {
            foreach (IWebElement element in GetIWebElements())
            {
                string name = element.FindElement(productName).Text;
                string description = element.FindElement(productDescription).Text;
                double price = double.Parse(element.FindElement(productPrice).Text.Split('$')[1]);

                if (name.ToLower() == product.Name)
                {
                    choosenProducts.Add(new ProductModel(name, description, price));
                    element.FindElement(addToCartButton).Click();
                }
            }

        }

        private IReadOnlyCollection<IWebElement> GetIWebElements()
        {
            return driver.FindElement(inventoryList).FindElements(By.ClassName("inventory_item"));
        }
    }
}
