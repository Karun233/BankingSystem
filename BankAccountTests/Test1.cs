using BankClassLibrary;
using System.Security.Principal;

namespace BankAccountTests
{
    [TestClass]
    public sealed class BankAccountTests
    {
        [TestMethod]
        public void TestDeposit()
        {
            Account account = new Account(100M, "12345678", "12-34-56", "Hello", "Current");
            account.Deposit(50M);
            Assert.AreEqual(150M, account.AccountBalance);
        }

        [TestMethod]
        public void TestWithdraw()
        {
            Account account = new Account(200M, "12345678", "12-34-56", "Goodbyteee", "Credit");
            account.Withdraw(50M);
            Assert.AreEqual(150M, account.AccountBalance);
        }

        [TestMethod]
        public void TestNegativeBalance()
        {
            Account account = new Account(50M, "12345678", "12-34-56", "Johne", "Current");
            account.Withdraw(100M);
            Assert.AreEqual(50M, account.AccountBalance);
        }

        [TestMethod]
        public void TestRegister()
        {
            Account account = new Account(500M, "99999999", "99-99-99", "New User", "Savings");
            Assert.AreEqual("New User", account.AccountName);
            Assert.AreEqual("99999999", account.AccountNumber);
            Assert.AreEqual(500M, account.AccountBalance);
        }

        [TestMethod]
        public void TestLogin()
        {
            List<Account> accounts = new List<Account>();
            Account account = new Account(100M, "12345678", "12-34-56", "Test User", "Current");
            accounts.Add(account);

            bool found = false;
            foreach (Account acc in accounts)
            {
                if (acc.AccountNumber == "12345678" && acc.AccountName == "Test User")
                {
                    found = true;
                    break;
                }
            }
            Assert.IsTrue(found);
        }
    }
}
