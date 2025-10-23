using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class CreditAccount : Account, IWithdrawable, IDepositable, IOverdraftable
    {

       
        private decimal overdraftLimit = 500M;

        public CreditAccount(decimal AccountBalance, string AccountNumber = "123", string SortCode = "23-34-56", string AccountName = "Trial accont", string AccountType = "Credit")
            : base(AccountBalance, AccountNumber, SortCode, AccountName, AccountType)
        {

        }

        public void SetOverdraftLimit(decimal limit)
        {
            overdraftLimit = limit;
        }

        public decimal GetOverdraftLimit()
        {
            return overdraftLimit;
        }

        public override void Withdraw(decimal amount)
        {
            if(AccountBalance - amount < -overdraftLimit)
            {
                Console.WriteLine("Exceeds overdraft limit!");
                return;
            }
            Console.WriteLine($"-£{amount} was withdrawn from the Account");

            base.Withdraw(amount);
        }

    }
}
