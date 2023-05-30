using NUnit.Framework;
using home_13.Pages;
using home_13.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace home_13.Tests
{
    class BuyProductsTests : TestBase
    {
        [Test]
        [Description("This test checks if user has choosen the right product")]
        public void AddToCartOneProduct()
        {
            List<ProductModel> products = new List<ProductModel>()
            {
                new ProductModel("Sauce Labs Backpack")
            };

            LoginPage.OpenPage().LoginAsStandardUser().AddToCart(products).OpenShoppingCart();
            Assert.AreEqual(InventoryPage.choosenProducts, CartPage.GetItemsFromCart());
        }

        [Test]
        [Description("This test checks if user has choosen the right products")]
        public void AddToCartProducts()
        {
            List<ProductModel> products = new List<ProductModel>()
            {
                new ProductModel("Sauce Labs Backpack"),
                new ProductModel("Sauce Labs Bike Light"),
            };

            LoginPage.OpenPage().LoginAsStandardUser().AddToCart(products).OpenShoppingCart();
            Assert.AreEqual(InventoryPage.choosenProducts, CartPage.GetItemsFromCart());
        }

        [Test]
        [Description("This test checks if user complete the order")]
        public void BuyOneProduct()
        {
            List<ProductModel> products = new List<ProductModel>()
            {
                new ProductModel("Sauce Labs Backpack")
            };

            CustomerModel customer = new CustomerModel("wef", "weerg", "2345");

            LoginPage.OpenPage().LoginAsStandardUser().AddToCart(products).OpenShoppingCart().ClickCheckoutButton().FillUpForm(customer).ClickContinueButton();

            double sumOfAllProducts = Math.Round(InventoryPage.choosenProducts.Sum(product => product.Price) + CheckoutPage.GetTax(), 2);

            Assert.AreEqual(InventoryPage.choosenProducts, CheckoutPage.GetItemsFromOverview());
            Assert.AreEqual(sumOfAllProducts, CheckoutPage.GetTotalPrice());

            CheckoutPage.ClickFinishButton();

            Assert.AreEqual("Thank you for your order!", CheckoutPage.GetFinishTitle());
        }

        [Test]
        [Description("This test checks if user complete the order")]
        public void BuyProducts()
        {
            List<ProductModel> products = new List<ProductModel>()
            {
                new ProductModel("Sauce Labs Backpack"),
                new ProductModel("Sauce Labs Bike Light"),
                new ProductModel("Sauce Labs Bolt T-Shirt"),
            };

            CustomerModel customer = new CustomerModel("wef", "weerg", "2345");

            LoginPage.OpenPage().LoginAsStandardUser().AddToCart(products).OpenShoppingCart().ClickCheckoutButton().FillUpForm(customer).ClickContinueButton();

            double sumOfAllProducts = Math.Round(InventoryPage.choosenProducts.Sum(product => product.Price) + CheckoutPage.GetTax(), 2);

            Assert.AreEqual(InventoryPage.choosenProducts, CheckoutPage.GetItemsFromOverview());
            Assert.AreEqual(sumOfAllProducts, CheckoutPage.GetTotalPrice());

            CheckoutPage.ClickFinishButton();

            Assert.AreEqual("Thank you for your order!", CheckoutPage.GetFinishTitle());
        }

        [Test]
        [Description("This test checks if user has bought the right product(s) if he|she removed one product from the cart")]
        public void BuyProductsWithoutOneProduct()
        {
            List<ProductModel> products = new List<ProductModel>()
            {
                new ProductModel("Sauce Labs Backpack"),
                new ProductModel("Sauce Labs Bike Light"),
                new ProductModel("Sauce Labs Bolt T-Shirt"),
            };

            CustomerModel customer = new CustomerModel("wef", "weerg", "2345");

            LoginPage.OpenPage().LoginAsStandardUser().AddToCart(products).OpenShoppingCart();

            List<ProductModel> productsForRemove = new List<ProductModel> { InventoryPage.choosenProducts[1] };
            List<ProductModel> newListProducts = InventoryPage.choosenProducts.Where(product => !productsForRemove.Contains(product)).ToList();

            CartPage.RemoveProduct(productsForRemove).ClickCheckoutButton().FillUpForm(customer).ClickContinueButton();

            double sumOfAllProducts = Math.Round(newListProducts.Sum(product => product.Price) + CheckoutPage.GetTax(), 2);

            Assert.AreEqual(newListProducts, CheckoutPage.GetItemsFromOverview());
            Assert.AreEqual(sumOfAllProducts, CheckoutPage.GetTotalPrice());

            CheckoutPage.ClickFinishButton();

            Assert.AreEqual("Thank you for your order!", CheckoutPage.GetFinishTitle());
        }

        [Test]
        [Description("This test checks if user has bought the right product(s) if he|she removed a several products from the cart")]
        public void BuyProductsWithoutSeveralProducts()
        {
            List<ProductModel> products = new List<ProductModel>()
            {
                new ProductModel("Sauce Labs Backpack"),
                new ProductModel("Sauce Labs Bike Light"),
                new ProductModel("Sauce Labs Bolt T-Shirt"),
            };

            CustomerModel customer = new CustomerModel("wef", "weerg", "2345");

            LoginPage.OpenPage().LoginAsStandardUser().AddToCart(products).OpenShoppingCart();

            List<ProductModel> productsForRemove = new List<ProductModel> { InventoryPage.choosenProducts[0], InventoryPage.choosenProducts[2] };
            List<ProductModel> newListProducts = InventoryPage.choosenProducts.Where(product => !productsForRemove.Contains(product)).ToList();

            CartPage.RemoveProduct(productsForRemove).ClickCheckoutButton().FillUpForm(customer).ClickContinueButton();

            double sumOfAllProducts = Math.Round(newListProducts.Sum(product => product.Price) + CheckoutPage.GetTax(), 2);

            Assert.AreEqual(newListProducts, CheckoutPage.GetItemsFromOverview());
            Assert.AreEqual(sumOfAllProducts, CheckoutPage.GetTotalPrice());

            CheckoutPage.ClickFinishButton();

            Assert.AreEqual("Thank you for your order!", CheckoutPage.GetFinishTitle());
        }
    }
}
