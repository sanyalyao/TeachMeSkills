using home_15.Elements;
using home_15.Helpers;
using home_15.Models;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace home_15.Pages
{
    public class ContactsPage : GeneralContractPage
    {
        private Button tabContactsButton = new Button("one-app-nav-bar-item-root", "data-id", "Contact");

        [AllureStep("Open the page with a table with Contacts")]
        public ContactsPage OpenContactsPage()
        {
            logger.Info("Navigating to the Contacts page");

            tabContactsButton.GetElement().Click();
            WaitHelper.WaitElement(driver, nameOfFirstColumnTableBy);
            return this;
        }

        [AllureStep("Go to the Contact page")]
        public ContactPage TakeContact(int sequenceNumber)
        {
            logger.Info($"Going to the Contact page");

            driver.Navigate().GoToUrl(GetContactsLinks()[sequenceNumber]);

            WaitHelper.WaitElement(driver, contactNameTitleBy);

            return new ContactPage();
        }


        [AllureStep("Check the Contact in the table")]
        public bool DoesContactNameExistInTable(ContactModel contact)
        {
            logger.Info("Checking does Contact Fullname exist in Contacts table");

            List<string> listOfContactsNames = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).Count != 0
                ? GetContactsNames()
                : new List<string>();

            return listOfContactsNames.Contains(contact.FullName);
        }

        public List<string> GetContactsNames()
        {
            List<IWebElement> rows = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).ToList();
            List<string> contactsNames = new List<string>();

            foreach (IWebElement row in rows)
            {
                contactsNames.Add(row.Text);
            }

            return contactsNames;
        }

        private List<string> GetContactsLinks()
        {
            List<string> linksToEachContact = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).Count != 0
                ? GetLinksFromTable()
                : new List<string>();

            return linksToEachContact;
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
