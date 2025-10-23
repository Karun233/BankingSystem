using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class SavingsAccount : Account, IWithdrawable, IDepositable
    {
        public SavingsAccount(decimal AccountBalance, string AccountNumber = "123", string SortCode = "23-34-56", string AccountName = "Trial accont", string AccountType = "Savings")
            : base(AccountBalance, AccountNumber, SortCode, AccountName, AccountType)
        {
        }

        public override void Withdraw(decimal amount)
        {
            if (AccountBalance < amount)
            {
                Console.WriteLine("You cannot go in Overdraft");
                return;
            }
            base.Withdraw(amount);
        }
    }
}
