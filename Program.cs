using System;

class Program
{
    public static void Main(string[] Args)
    {
        int option = 0;
        List<BankAccount> accounts = new List<BankAccount>();

        while (option != 6)
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("Welcome to your Banking System.");
            Console.WriteLine("===============================\n");

            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit Funds");
            Console.WriteLine("3. Withdraw Funds");
            Console.WriteLine("4. View Account");
            Console.WriteLine("5. List Accounts");
            Console.WriteLine("6. Exit\n");

            Console.Write("Please enter your option(1-6): ");
            option = int.TryParse(Console.ReadLine(), out option) ? option : 0;

            Console.Clear();

            HandleOption(option, accounts);

        }
    }

    // Function to handle options
    public static void HandleOption(int option, List<BankAccount> accounts)
    {
        switch (option)
        {
            // The following code is for the create account option
            case 1:
                Console.WriteLine("Create an account");
                Console.WriteLine("=================");

                BankAccount newAccount = CreateAccount();

                while (newAccount != null && accounts.Contains(newAccount)) {
                    Console.WriteLine("\nAccount already exists. Please enter a different account number.");
                    newAccount = CreateAccount();
                }

                if (newAccount == null)
                    break;

                accounts.Add(newAccount);
                Console.WriteLine("\nAccount created successfully.");
                Console.WriteLine("=============================================");
                Console.WriteLine("Account Number | Balance | Total Transactions");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(newAccount);
                break;

            // The following code is for the deposit option
            case 2:
                Console.WriteLine("Deposit Funds");   
                Console.WriteLine("==============\n");   
            
                BankAccount depositAccount = GetAccount(accounts);

                if (depositAccount == null)
                    break;

                decimal amount = GetAmountInput(TransactionType.Deposit);

                if (amount == 0)
                {
                    Console.WriteLine("\nInvalid amount entered. Please try again.");
                    break;
                }
                
                Console.WriteLine("\nTransaction Details:");
                Console.WriteLine("Type       | Amount     | Date");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(depositAccount.Deposit(amount));

                break;

            // The following code is for the withdraw option
            case 3:
                Console.WriteLine("Withdraw Funds");
                Console.WriteLine("==============\n");

                BankAccount withdrawAccount = GetAccount(accounts);

                if (withdrawAccount == null)
                    break;

                decimal withdrawAmount = GetAmountInput(TransactionType.Withdrawal);

                if (withdrawAmount == 0)
                {
                    Console.WriteLine("\nInvalid amount entered. Please try again.");
                    break;
                }

                try {
                    Console.WriteLine("\nTransaction Details:");
                    Console.WriteLine("Type       | Amount     | Date");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine(withdrawAccount.Withdraw(withdrawAmount));
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }

                break;

            // The following code is for the view account option
            case 4:
                Console.WriteLine("View All your accont information here:");
                Console.WriteLine("=====================================\n");

                BankAccount acc = GetAccount(accounts);

                if (acc == null)
                    break;

                Console.WriteLine("\nAccount Number: " + acc.GetAccountNumber());
                Console.WriteLine("Balance: " + acc.GetBalance());

                Console.WriteLine("\nTransaction History");
                Console.WriteLine("=============================================");
                Console.WriteLine("Type       | Amount     | Date");
                Console.WriteLine("---------------------------------------------");

                foreach (Transaction t in acc.GetTransactions())
                    Console.WriteLine(t);

                break;

            // The following code is for the list accounts option
            case 5:
                Console.WriteLine("All Accounts currently in the system:");
                Console.WriteLine("=====================================");

                Console.WriteLine("\nAccount Number | Balance | Total Transactions");
                Console.WriteLine("---------------------------------------------");

                foreach (BankAccount item in accounts)
                    Console.WriteLine(item);

                break;

            case 6:
                Console.WriteLine("Exit");
                return;

            default:
                Console.WriteLine("Invalid Option, please try again.");
                break;
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    public static BankAccount CreateAccount() 
    {
        int accountNumber = 0;

        Console.Write("Please enter your account number [X to Cancel]: ");
        bool success = int.TryParse(Console.ReadLine(), out accountNumber);

        if (!success)
            return null;

        return new BankAccount(accountNumber);
    }

    public static decimal GetAmountInput(TransactionType type)
    {
        decimal amount = 0;

        Console.Write("Please enter the amount to " + type + " [X to Cancel]: ");
        bool success = Decimal.TryParse(Console.ReadLine(), out amount);

        if (!success)
            return 0;

        return amount;
    }

    public static BankAccount GetAccount(List<BankAccount> accounts)
    {
        Console.Write("Please enter your account number [X to Cancel]: ");
        bool success = int.TryParse(Console.ReadLine(), out int accountNumber);

        if (!success)
            return null;

        BankAccount account = accounts.Find(a => a.GetAccountNumber() == accountNumber);

        if (account == null) {
            Console.WriteLine("Account not found.");
            return null;
        }

        return account;
    }
}