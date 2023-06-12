using home_15.Models;
using NUnit.Framework;
using home_15.Helpers;

namespace home_15.Tests
{
    class ContactTests : TestBase
    {
        [Test]
        [Description("Create contact")]
        public void CreateContact()
        {
            Login();

            ContactModel newContact = new CreationHelper().CreateContact();

            ContactPage.OpenContactPage().CreateNewContact(newContact);

            Assert.AreEqual(newContact, ContactPage.GetContactDetails());
        }

        [Test]
        [Description("Edit old Contact")]
        public void EditContact()
        {
            Login();

            ContactModel oldContact;

            try
            {
                oldContact = ContactPage.OpenContactPage().TakeContact(0).GetContactDetails();
            }
            catch
            {
                oldContact = new CreationHelper().CreateContact();

                ContactPage.CreateNewContact(oldContact);
            }

            ContactModel newContact = new CreationHelper().CreateContact();
            ContactModel changedContact = ContactPage.EditContact(newContact).GetContactDetails();

            Assert.AreEqual(newContact, changedContact);
            Assert.AreNotEqual(changedContact, oldContact);
        }

        [Test]
        [Description("Delete old Contact")]
        public void DeleteContact()
        {
            Login();

            ContactModel oldContact;
            int countOfContactsBefore;

            ContactPage.OpenContactPage();

            try
            {
                countOfContactsBefore = ContactPage.GetTableOfContacts().Count;
                oldContact = ContactPage.TakeContact(0).GetContactDetails();

                ContactPage.DeleteContact();
            }
            catch
            {
                oldContact = new CreationHelper().CreateContact();

                ContactPage.CreateNewContact(oldContact);
                ContactPage.OpenContactPage();

                countOfContactsBefore = ContactPage.GetTableOfContacts().Count;

                ContactPage.TakeContact(0).DeleteContact();
            }

            int countOfContactsAfter = ContactPage.GetTableOfContacts().Count;

            Assert.AreEqual(countOfContactsBefore - 1, countOfContactsAfter);
            Assert.IsFalse(ContactPage.DoesContactNameExistInTable(oldContact));
        }
    }
}
