using System.ComponentModel.Design;
namespace BankClassLibrary
{
    public class Account
    {
        private decimal accountBalance;
        private string accountNumber;
        private string sortCode;
        private string accountName;
        private string accountType;
        private List<string> validAccountTypes = new List<string>()
        {
            "Current",
            "Savings",
            "Credit"
        };
        public Account(decimal AccountBalance, string AccountNumber, string SortCode, string AccountName, string AccountType)
        {
            this.accountBalance = AccountBalance;
            this.accountNumber = AccountNumber;
            this.sortCode = SortCode;
            this.accountName = AccountName;
            this.accountType = AccountType;
        }
        public decimal AccountBalance
        {
            get
            {
                return accountBalance;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.accountBalance = value;
            }
        }
        public string AccountName
        {
            get
            {
                return accountName; 
            }
            set
            {
                accountName = value;
            }
        }
        public string AccountNumber
        {
            get
            {
                return accountNumber; 
            }
            set
            {
                accountNumber = value;
            }
        }
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("You can't deposit a negative number!");
            }
            else
            {
                Console.WriteLine($"£{amount} was deposited to the Account");
                accountBalance += amount;
                DisplayDetails();
            }

        }
        public void Withdraw(decimal amount)
        {
            
            if ((this.accountType == "Current" || this.accountType == "Savings") && accountBalance < amount)
            {
                Console.WriteLine("You cannot go in Overdraft");
                return; 
            }
            Console.WriteLine($"-£{amount} was withdrawn from the Account");
            accountBalance -= amount;
            DisplayDetails();
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Account Name: {accountName}");
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Account Sortcode: {sortCode}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Account Balance: £{accountBalance}");
        }
        public void Login()
        {
            bool active = true;
            while (active)
            {
                Console.WriteLine("\n--Options--");
                Console.WriteLine("1) Check Balance");
                Console.WriteLine("2) Deposit Money");
                Console.WriteLine("3) Withdraw Money");
                Console.WriteLine("4) Exit");
                Console.Write("Choose an option: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    DisplayDetails();
                }
                else if (choice == 2)
                {
                    Console.Write("Enter amount to deposit: £");
                    decimal depositAmount = decimal.Parse(Console.ReadLine());
                    Deposit(depositAmount);
                }
                else if (choice == 3)
                {
                    Console.Write("Enter amount to withdraw: £");
                    decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                    Withdraw(withdrawAmount);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Logging out...");
                    active = false;
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }
            }
        }
    }
}