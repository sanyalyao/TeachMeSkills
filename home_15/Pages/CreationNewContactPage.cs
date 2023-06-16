using home_15.Elements;
using home_15.Helpers;
using home_15.Models;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace home_15.Pages
{
    public class CreationNewContactPage : GeneralContractPage
    {
        private static By newContactBy = By.CssSelector("a[title='New']");
        private By newContactTitle = By.CssSelector("h2[class='slds-modal__title slds-hyphenate slds-text-heading--medium']");

        private Button newContactButton = new Button(newContactBy);

        [AllureStep("Create new Contact")]
        public ContactPage CreateNewContact(ContactModel contact)
        {
            logger.Info($"Creating new Contact\nContact Fullname - {contact.FullName}");

            Actions action = new Actions(driver);

            newContactButton.GetElement().Click();

            WaitHelper.WaitElement(driver, newContactTitle);

            firstNameInput.GetElement().SendKeys(contact.FirstName);
            lastNameInput.GetElement().SendKeys(contact.LastName);
            mobileInput.GetElement().SendKeys(contact.Mobile);
            emailInput.GetElement().SendKeys(contact.Email);

            action.ScrollToElement(mailingStreetInput.GetElement()).Release();

            mailingStreetInput.GetElement().SendKeys(contact.MailingStreet);
            mailingZipInput.GetElement().SendKeys(contact.MailingZip);
            mailingCityInput.GetElement().SendKeys(contact.MailingCity);
            mailingCountryInput.GetElement().SendKeys(contact.MailingCountry);

            saveNewContactButton.GetElement().Click();

            WaitHelper.WaitElement(driver, contactNameTitleBy);

            return new ContactPage();
        }
    }
}
