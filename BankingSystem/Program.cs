using BankClassLibrary;
using System.ComponentModel.Design;
using System.Globalization;
using System.Security.Principal;
using System.Xml.Serialization;

List<Account> accounts = new List<Account>();
bool active = true;

while (active)
{
    Console.WriteLine("\n--Bank Options--");
    Console.WriteLine("1) Login");
    Console.WriteLine("2) Register");
    Console.WriteLine("3) Exit");
    Console.Write("Choose an option: ");

    int option = int.Parse(Console.ReadLine());

    if (option == 1)
    {
        Console.Write("Enter your Account Number to login: ");
        string accNum = Console.ReadLine();
        Console.Write("Enter your Account Name to login: ");
        string accName = Console.ReadLine();

        bool LoggedIn = false;
        Account AccLoggedIn = null; 

        foreach (Account account in accounts)
        {
            
            if (accNum == account.AccountNumber && accName == account.AccountName)
            {
                LoggedIn = true;
                AccLoggedIn = account;
                Console.WriteLine("Log in Successful!");
                break;
            }
        }

        if (LoggedIn)
        {
            
            AccLoggedIn.Login();
        }
        else
        {
            Console.WriteLine("Wrong details");
        }
    }
    else if (option == 2)
    {
        Console.WriteLine("\n--Register New Account--");

        Console.Write("Enter Account Name: ");
        string newAccountName = Console.ReadLine();

        Console.Write("Enter Account Number: ");
        string newAccountNumber = Console.ReadLine();

        Console.Write("Enter Sort Code: ");
        string newSortCode = Console.ReadLine();

        Console.Write("Enter Account Type (Current/Savings/Credit/ISA): ");
        string newAccountType = Console.ReadLine();

        

        Console.Write("Enter Initial Balance: £");
        decimal newBalance = decimal.Parse(Console.ReadLine());

        if (newAccountType == "ISA")
        {
            IsaAccount isa = new IsaAccount(newBalance, newAccountNumber, newSortCode, newAccountName, newAccountType);
            accounts.Add(isa);
            Console.WriteLine("\nAccount created successfully!");
            isa.DisplayDetails();
        }
        else if(newAccountType == "Current")
        {
            CurrentAccount newAccount = new CurrentAccount(newBalance, newAccountNumber, newSortCode, newAccountName, newAccountType);
            accounts.Add(newAccount);
            Console.WriteLine("\nAccount created successfully!");
            newAccount.DisplayDetails();
        }
        else if (newAccountType == "Savings")
        {
            SavingsAccount newAccount = new SavingsAccount(newBalance, newAccountNumber, newSortCode, newAccountName, newAccountType);
            accounts.Add(newAccount);
            Console.WriteLine("\nAccount created successfully!");
            newAccount.DisplayDetails();
        }
        else if (newAccountType == "Credit")
        {
            CreditAccount newAccount = new CreditAccount(newBalance, newAccountNumber, newSortCode, newAccountName, newAccountType);
            accounts.Add(newAccount);
            Console.WriteLine("\nAccount created successfully!");
            newAccount.DisplayDetails();
        }
        else
        {
            Console.WriteLine("Not a valid account type");

        }

    }
    else if (option == 3)
    {
        active = false;
        Console.WriteLine("Exiting...");
    }
    else
    {
        Console.WriteLine("Invalid input");
    }
}