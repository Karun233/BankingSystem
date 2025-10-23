using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class IsaAccount : Account, IWithdrawable, IDepositable
    {
        private decimal YearlyLimit = 20000M;

        public IsaAccount(decimal AccountBalance, string AccountNumber = "123", string SortCode = "23-34-56", string AccountName = "Trial accont", string AccountType = "ISA")
            : base(AccountBalance, AccountNumber, SortCode, AccountName, AccountType)
        {
        }

        public string limitLeft()
        {
            return $"The amount left to deposit this year is {YearlyLimit - this.AccountBalance}";
        }

        public override void DisplayDetails()
        {
             
            base.DisplayDetails();
            Console.WriteLine($"The yearly limit left on ISA is: {limitLeft()}");

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
