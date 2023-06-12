using home_15.Elements;
using home_15.Models;
using home_15.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace home_15.Pages
{
    public class AccountPage : BasePage
    {
        private const string url = "https://ozatvn2-dev-ed.develop.lightning.force.com/lightning/o/Account/list?filterName=Recent";

        private static By newAccountBy = By.CssSelector("a[title='New']");
        private By nameOfFirstColumnTableBy = By.CssSelector("span[title='Account Name']");
        private By newAccountTitle = By.CssSelector("h2[class='slds-modal__title slds-hyphenate slds-text-heading--medium']");
        private By accountNameTitleBy = By.ClassName("custom-truncate");
        private By accountNameField = By.CssSelector("records-record-layout-item[field-label='Account Name'] > div > div > div:nth-child(2) *> lightning-formatted-text");
        private By accountPhoneField = By.CssSelector("records-record-layout-item[field-label='Phone'] > div > div > div:nth-child(2) *> a");
        private By accountAccountNumberField = By.CssSelector("records-record-layout-item[field-label='Account Number'] > div > div > div:nth-child(2) *> lightning-formatted-text");
        private By addressField = By.CssSelector("records-record-layout-item[field-label='Billing Address'] > div > div > div:nth-child(2) *> a");
        private By detailsBy = By.CssSelector("a[data-label='Details']");
        private By tableOfAccountBy = By.CssSelector("table[aria-label='Recently Viewed'] > tbody");

        private Button newAccountButton = new Button(newAccountBy);
        private Button saveNewAccountButton = new Button("button", "name", "SaveEdit");
        private Button editAccountButton = new Button(By.CssSelector("records-record-layout-item[field-label='Account Name'] > div > div > div:nth-child(2) > button"));
        private Button listOfCommandsButton = new Button("li", "class", "slds-dropdown-trigger slds-dropdown-trigger_click slds-button_last overflow");
        private Button deleteAccountButton = new Button(By.CssSelector("runtime_platform_actions-action-renderer[apiname='Delete'] *> span"));
        private Button confirmDeleteAccountButton = new Button("button", "title", "Delete");

        private Input accountNameInput = new Input("input", "name", "Name");
        private Input phoneInput = new Input("input", "name", "Phone");
        private Input accountNumberInput = new Input("input", "name", "AccountNumber");
        private Input billingStreetInput = new Input("textarea", "name", "street");
        private Input billingZipInput = new Input("input", "name", "postalCode");
        private Input billingCityInput = new Input("input", "name", "city");
        private Input billingCountryInput = new Input("input", "name", "country");

        public AccountPage OpenAccountPage()
        {
            driver.Navigate().GoToUrl(url);
            WaitHelper.WaitElement(driver, nameOfFirstColumnTableBy);
            return this;
        }

        public AccountPage CreateNewAccount(AccountModel account)
        {
            Actions action = new Actions(driver);

            newAccountButton.GetElement().Click();

            WaitHelper.WaitElement(driver, newAccountTitle);

            accountNameInput.GetElement().SendKeys(account.AccountName);
            phoneInput.GetElement().SendKeys(account.Phone);
            accountNumberInput.GetElement().SendKeys(account.AccountNumber);

            action.ScrollToElement(billingStreetInput.GetElement()).Release();
            
            billingStreetInput.GetElement().SendKeys(account.BillingStreet);
            billingZipInput.GetElement().SendKeys(account.BillingZip);
            billingCityInput.GetElement().SendKeys(account.BillingCity);
            billingCountryInput.GetElement().SendKeys(account.BillingCountry);
            saveNewAccountButton.GetElement().Click();

            WaitHelper.WaitElement(driver, accountNameTitleBy);
 
            return this;
        }        

        public AccountPage TakeAccount(int sequenceNumber)
        {
            driver.Navigate().GoToUrl(GetLinksOfAccountsFromTable()[sequenceNumber]);

            WaitHelper.WaitElement(driver, accountNameTitleBy);

            return this;
        }

        public AccountPage EditAccount(AccountModel newAccount)
        {
            Actions action = new Actions(driver);

            driver.FindElement(detailsBy).Click();

            action.Click(editAccountButton.GetElement()).Build().Perform();

            accountNameInput.GetElement().Clear();
            accountNameInput.GetElement().Clear();
            accountNameInput.GetElement().SendKeys(newAccount.AccountName);

            phoneInput.GetElement().Clear();
            phoneInput.GetElement().SendKeys(newAccount.Phone);

            accountNumberInput.GetElement().Clear();
            accountNumberInput.GetElement().SendKeys(newAccount.AccountNumber);

            action.ScrollToElement(billingStreetInput.GetElement()).Release();

            billingStreetInput.GetElement().Clear();
            billingStreetInput.GetElement().SendKeys(newAccount.BillingStreet);

            billingZipInput.GetElement().Clear();
            billingZipInput.GetElement().SendKeys(newAccount.BillingZip);

            billingCityInput.GetElement().Clear();
            billingCityInput.GetElement().SendKeys(newAccount.BillingCity);

            billingCountryInput.GetElement().Clear();
            billingCountryInput.GetElement().SendKeys(newAccount.BillingCountry);

            saveNewAccountButton.GetElement().Click();

            return this;
        }

        public AccountPage DeleteAccount()
        {
            Actions action = new Actions(driver);

            listOfCommandsButton.GetElement().Click();
            action.Click(deleteAccountButton.GetElement()).Build().Perform();
            confirmDeleteAccountButton.GetElement().Click();

            return this;
        }

        public AccountModel GetAccountDetails()
        {
            Actions action = new Actions(driver);

            driver.FindElement(detailsBy).Click();

            WaitHelper.WaitElement(driver, accountNameField);

            string accountName = GetText(accountNameField);
            string phone = GetText(accountPhoneField);
            string accountNumber = GetText(accountAccountNumberField);
            string address;

            try
            {
                action.ScrollToElement(driver.FindElement(addressField)).Release();

                address = driver.FindElement(addressField).GetAttribute("aria-label").Replace("\r\n","").Replace(" ", "");
            }
            catch
            {
                address = "";
            }

            AccountModel account = new AccountModel(accountName, phone, accountNumber, address);

            return account;
        }

        public bool DoesAccountNameExistInTable(AccountModel account)
        {
            List<string> listOfAccountNames;

            try
            {
                listOfAccountNames = GetTableOfAccounts().Select(row => row.FindElement(By.CssSelector("th[scope='row'] > span > a")).Text).ToList();
            }
            catch
            {
                listOfAccountNames = new List<string>();
            }

            return listOfAccountNames.Contains(account.AccountName);
        }

        public List<IWebElement> GetTableOfAccounts()
        {
            List<IWebElement> tableOfAccounts;

            try
            {
                tableOfAccounts = driver.FindElement(tableOfAccountBy).FindElements(By.TagName("tr")).ToList();
            }
            catch
            {
                tableOfAccounts = new List<IWebElement>();
            }

            return tableOfAccounts;
        }

        private List<string> GetLinksOfAccountsFromTable()
        {
            List<string> linksToEachAccount = new List<string>();
            GetTableOfAccounts().ForEach(row => linksToEachAccount.Add(row.FindElement(By.CssSelector("th[scope='row'] > span > a")).GetAttribute("href")));

            return linksToEachAccount;
        }

        private string GetText(By by)
        {
            try
            {
                return driver.FindElement(by).Text;
            }
            catch
            {
                return "";
            }
        }
    }
}