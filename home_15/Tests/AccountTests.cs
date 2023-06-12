using home_15.Tests;
using home_15.Models;
using NUnit.Framework;
using home_15.Helpers;

namespace home_15
{
    public class AccountTests : TestBase
    {
        [Test]
        [Description("Create new account")]
        public void CreateAccount()
        {
            Login();

            AccountModel newAccount = new CreationHelper().CreateAccount();

            AccountPage.OpenAccountPage().CreateNewAccount(newAccount);

            Assert.AreEqual(newAccount, AccountPage.GetAccountDetails());
        }

        [Test]
        [Description("Edit old account")]
        public void EditAccount()
        {
            Login();

            AccountModel oldAccount;

            try
            {
                oldAccount = AccountPage.OpenAccountPage().TakeAccount(0).GetAccountDetails();
            }
            catch
            {
                oldAccount = new CreationHelper().CreateAccount();

                AccountPage.CreateNewAccount(oldAccount);
            }

            AccountModel newAccount = new CreationHelper().CreateAccount();
            AccountModel changedAccount = AccountPage.EditAccount(newAccount).GetAccountDetails();

            Assert.AreEqual(newAccount, changedAccount);
            Assert.AreNotEqual(changedAccount, oldAccount);
        }

        [Test]
        [Description("Delete old account")]
        public void DeleteAccount()
        {
            Login();

            AccountModel oldAccount;
            int countOfAccountsBefore;

            AccountPage.OpenAccountPage();

            try
            {
                countOfAccountsBefore = AccountPage.GetTableOfAccounts().Count;
                oldAccount = AccountPage.TakeAccount(0).GetAccountDetails();

                AccountPage.DeleteAccount();
            }
            catch
            {
                oldAccount = new CreationHelper().CreateAccount();

                AccountPage.CreateNewAccount(oldAccount);
                AccountPage.OpenAccountPage();

                countOfAccountsBefore = AccountPage.GetTableOfAccounts().Count;

                AccountPage.TakeAccount(0).DeleteAccount();
            }

            int countOfAccountsAfter = AccountPage.GetTableOfAccounts().Count;

            Assert.AreEqual(countOfAccountsBefore - 1, countOfAccountsAfter);
            Assert.IsFalse(AccountPage.DoesAccountNameExistInTable(oldAccount));
        }
    }
}
