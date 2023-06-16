using home_15.Elements;
using home_15.Helpers;
using home_15.Models;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace home_15.Pages
{
    public class AccountsPage : GeneralAccountPage
    {
        private Button tabAccountsButton = new Button("one-app-nav-bar-item-root", "data-id", "Account");

        [AllureStep("Open the page with a table with Accounts")]
        public AccountsPage OpenAccountsPage()
        {
            logger.Info("Navigating to the Accounts page");

            tabAccountsButton.GetElement().Click();
            WaitHelper.WaitElement(driver, nameOfFirstColumnTableBy);
            return this;
        }

        [AllureStep("Go to the Account page")]
        public AccountPage TakeAccount(int sequenceNumber)
        {
            logger.Info("Going to the Account page");

            driver.Navigate().GoToUrl(GetAccountsLinks()[sequenceNumber]);

            WaitHelper.WaitElement(driver, accountNameTitleBy);

            return new AccountPage();
        }

        [AllureStep("Check the Account in the table")]
        public bool DoesAccountNameExistInTable(AccountModel account)
        {
            logger.Info("Checking does Account Name exist in Accounts table");

            List<string> listOfAccountNames = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).Count != 0
                ? GetAccountsNames()
                : new List<string>();

            return listOfAccountNames.Contains(account.AccountName);
        }

        public List<string> GetAccountsNames()
        {
            List<IWebElement> rows = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).ToList();
            List<string> accountsNames = new List<string>();

            foreach (IWebElement row in rows)
            {
                accountsNames.Add(row.Text);
            }

            return accountsNames;
        }

        private List<string> GetAccountsLinks()
        {
            List<string> linksToEachAccount = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).Count != 0
                ? GetLinksFromTable()
                : new List<string>();

            return linksToEachAccount;
        }

        private List<string> GetLinksFromTable()
        {
            List<IWebElement> rows = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).ToList();
            List<string> links = new List<string>();

            foreach (IWebElement row in rows)
            {
                links.Add(row.GetAttribute("href"));
            }

            return links;
        }
    }
}
