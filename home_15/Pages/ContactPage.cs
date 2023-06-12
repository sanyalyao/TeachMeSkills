using home_15.Elements;
using home_15.Models;
using home_15.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace home_15.Pages
{
    public class ContactPage : BasePage
    {
        private const string url = "https://ozatvn2-dev-ed.develop.lightning.force.com/lightning/o/Contact/list?filterName=Recent";

        private static By newContactBy = By.CssSelector("a[title='New']");
        private By nameOfFirstColumnTableBy = By.CssSelector("span[title='Name']");
        private By newContactTitle = By.CssSelector("h2[class='slds-modal__title slds-hyphenate slds-text-heading--medium']");
        private By contactNameTitleBy = By.ClassName("custom-truncate");
        private By tableOfContactBy = By.CssSelector("table[aria-label='Recently Viewed'] > tbody");
        private By detailsBy = By.CssSelector("a[data-label='Details']");
        private By contactNameFieldBy = By.CssSelector("records-record-layout-item[field-label='Name'] > div > div > div:nth-child(2) *> lightning-formatted-name");
        private By mobileFieldBy = By.CssSelector("records-record-layout-item[field-label='Mobile'] > div > div > div:nth-child(2) *> a");
        private By emailFieldBy = By.CssSelector("records-record-layout-item[field-label='Email'] > div > div > div:nth-child(2) *> a");
        private By addressField = By.CssSelector("records-record-layout-item[field-label='Mailing Address'] > div > div > div:nth-child(2) *> a");

        private Button newContactButton = new Button(newContactBy);
        private Button saveNewContactButton = new Button("button", "name", "SaveEdit");
        private Button editContactButton = new Button(By.CssSelector("records-record-layout-item[field-label='Account Name'] > div > div > div:nth-child(2) > button"));
        private Button listOfCommandsButton = new Button("li", "class", "slds-dropdown-trigger slds-dropdown-trigger_click slds-button_last overflow");
        private Button deleteContactButton = new Button(By.CssSelector("runtime_platform_actions-action-renderer[apiname='Delete'] *> span"));
        private Button confirmDeleteContactButton = new Button("button", "title", "Delete");

        private Input firstNameInput = new Input("input", "name", "firstName");
        private Input lastNameInput = new Input("input", "name", "lastName");
        private Input mobileInput = new Input("input", "name", "MobilePhone");
        private Input emailInput = new Input("input", "name", "Email");
        private Input mailingStreetInput = new Input("textarea", "name", "street");
        private Input mailingZipInput = new Input("input", "name", "postalCode");
        private Input mailingCityInput = new Input("input", "name", "city");
        private Input mailingCountryInput = new Input("input", "name", "country");

        public ContactPage OpenContactPage()
        {
            driver.Navigate().GoToUrl(url);
            WaitHelper.WaitElement(driver, nameOfFirstColumnTableBy);
            return this;
        }

        public ContactPage CreateNewContact(ContactModel contact)
        {
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

            return this;
        }

        public ContactPage TakeContact(int sequenceNumber)
        {
            driver.Navigate().GoToUrl(GetLinksOfContactsFromTable()[sequenceNumber]);

            WaitHelper.WaitElement(driver, contactNameTitleBy);

            return this;
        }

        public ContactPage EditContact(ContactModel newContact)
        {
            Actions action = new Actions(driver);

            driver.FindElement(detailsBy).Click();

            action.Click(editContactButton.GetElement()).Build().Perform();

            firstNameInput.GetElement().Clear();
            firstNameInput.GetElement().Clear();
            firstNameInput.GetElement().SendKeys(newContact.FirstName);

            lastNameInput.GetElement().Clear();
            lastNameInput.GetElement().SendKeys(newContact.LastName);

            mobileInput.GetElement().Clear();
            mobileInput.GetElement().SendKeys(newContact.Mobile);

            emailInput.GetElement().Clear();
            emailInput.GetElement().SendKeys(newContact.Email);

            action.ScrollToElement(mailingStreetInput.GetElement()).Release();

            mailingStreetInput.GetElement().Clear();
            mailingStreetInput.GetElement().SendKeys(newContact.MailingStreet);

            mailingZipInput.GetElement().Clear();
            mailingZipInput.GetElement().SendKeys(newContact.MailingZip);

            mailingCityInput.GetElement().Clear();
            mailingCityInput.GetElement().SendKeys(newContact.MailingCity);

            mailingCountryInput.GetElement().Clear();
            mailingCountryInput.GetElement().SendKeys(newContact.MailingCountry);

            saveNewContactButton.GetElement().Click();

            return this;
        }

        public ContactPage DeleteContact()
        {
            Actions action = new Actions(driver);

            listOfCommandsButton.GetElement().Click();
            action.Click(deleteContactButton.GetElement()).Build().Perform();
            confirmDeleteContactButton.GetElement().Click();

            return this;
        }

        public ContactModel GetContactDetails()
        {
            Actions action = new Actions(driver);

            driver.FindElement(detailsBy).Click();

            WaitHelper.WaitElement(driver, contactNameFieldBy);

            string firstNameLastName = GetText(contactNameFieldBy).Replace(" ", "");
            string mobile = GetText(mobileFieldBy);
            string email = GetText(emailFieldBy);
            string address;

            try
            {
                action.ScrollToElement(driver.FindElement(addressField)).Release();

                address = driver.FindElement(addressField).GetAttribute("aria-label").Replace("\r\n", "").Replace(" ", "");
            }
            catch
            {
                address = "";
            }

            ContactModel account = new ContactModel(firstNameLastName, mobile, email, address);

            return account;
        }

        public bool DoesContactNameExistInTable(ContactModel contact)
        {
            List<string> listOfContactsNames;

            try
            {
                listOfContactsNames = GetTableOfContacts().Select(row => row.FindElement(By.CssSelector("th[scope='row'] > span > a")).Text.Replace(" ","")).ToList();
            }
            catch
            {
                listOfContactsNames = new List<string>();
            }

            return listOfContactsNames.Contains(contact.FullName);
        }

        public List<IWebElement> GetTableOfContacts()
        {
            List<IWebElement> tableOfContacts;

            try
            {
                tableOfContacts = driver.FindElement(tableOfContactBy).FindElements(By.TagName("tr")).ToList();
            }
            catch
            {
                tableOfContacts = new List<IWebElement>();
            }

            return tableOfContacts;
        }

        private List<string> GetLinksOfContactsFromTable()
        {
            List<string> linksToEachContact= new List<string>();
            GetTableOfContacts().ForEach(row => linksToEachContact.Add(row.FindElement(By.CssSelector("th[scope='row'] > span > a")).GetAttribute("href")));

            return linksToEachContact;
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
