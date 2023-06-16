using home_15.Elements;
using home_15.Models;
using home_15.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Allure.Attributes;

namespace home_15.Pages
{
    public class CreationNewAccountPage : GeneralAccountPage
    {
        private static By newAccountBy = By.CssSelector("a[title='New']");
        private By newAccountTitle = By.CssSelector("h2[class='slds-modal__title slds-hyphenate slds-text-heading--medium']");

        private Button newAccountButton = new Button(newAccountBy);

        [AllureStep("Create new Account")]
        public AccountPage CreateNewAccount(AccountModel account)
        {

            logger.Info($"Creating new Account\nAccount Name - {account.AccountName}'\nAccount Number - {account.AccountNumber}");

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

            return new AccountPage();
        }
    }
}
