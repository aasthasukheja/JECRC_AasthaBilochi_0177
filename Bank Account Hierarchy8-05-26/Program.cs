using System;

namespace BankAccountHierarchy
{
    // Base Class
    class BankAccount
    {
        // Readonly Property
        public string accountNumber { get; }

        // Private Set Property
        protected double balance { get; private set; }

        // Constructor
        public BankAccount(string accountNumber, double initialBalance)
        {
            this.accountNumber = accountNumber;
            balance = initialBalance;
        }

        // Deposit Method
        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                return true;
            }

            return false;
        }

        // Withdraw Method
        public virtual bool Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                return true;
            }

            return false;
        }

        // Get Balance Method
        public double GetBalance()
        {
            return balance;
        }

        // Protected Method to Update Balance
        protected void UpdateBalance(double newBalance)
        {
            balance = newBalance;
        }
    }

    // SavingsAccount Class
    class SavingsAccount : BankAccount
    {
        public double interestRate;
        public double minimumBalance = 1000;

        // Constructor
        public SavingsAccount(string accountNumber, double initialBalance)
            : base(accountNumber, initialBalance)
        {
        }

        // Override Withdraw
        public override bool Withdraw(double amount)
        {
            if (GetBalance() - amount < minimumBalance)
            {
                Console.WriteLine(
                    $"Withdrawal Failed: Minimum balance requirement {minimumBalance}"
                );

                return false;
            }

            UpdateBalance(GetBalance() - amount);

            Console.WriteLine($"Withdrawal Successful,Remaining:{GetBalance()}");

            return true;
        }

        // Apply Interest
        public void ApplyInterest(double rate)
        {
            interestRate = rate;

            double interest = GetBalance() * rate / 100;

            UpdateBalance(GetBalance() + interest);

            Console.WriteLine(
                $"Interest Applied,Rate:{interestRate},New Balance:{GetBalance()}"
            );
        }
    }

    // CurrentAccount Class
    class CurrentAccount : BankAccount
    {
        public double overdraftLimit;
        public double transactionFee;

        // Constructor
        public CurrentAccount(
            string accountNumber,
            double initialBalance,
            double overdraftLimit = 2000,
            double transactionFee = 100
        )
            : base(accountNumber, initialBalance)
        {
            this.overdraftLimit = overdraftLimit;
            this.transactionFee = transactionFee;
        }

        // Override Withdraw
        public override bool Withdraw(double amount)
        {
            if (GetBalance() - amount >= -overdraftLimit)
            {
                UpdateBalance(GetBalance() - amount);

                Console.WriteLine(
                    $"Withdrawal Successful,Remaining:{GetBalance()}"
                );

                return true;
            }

            Console.WriteLine("Withdrawal Failed: Overdraft limit exceeded");

            return false;
        }

        // Deduct Transaction Fee
        public void DeductTransactionFee()
        {
            UpdateBalance(GetBalance() - transactionFee);

            Console.WriteLine(
                $"Fee Deducted,Amount:{transactionFee},Remaining:{GetBalance()}"
            );
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Input Account Type
            string accountType = Console.ReadLine()!;

            // Input Account Number
            string accountNumber = Console.ReadLine()!;

            // Initial Deposit
            double initialDeposit = double.Parse(Console.ReadLine()!);

            BankAccount account;

            // Create Object
            if (accountType.ToLower() == "savings")
            {
                account = new SavingsAccount(accountNumber, initialDeposit);
            }
            else
            {
                account = new CurrentAccount(accountNumber, initialDeposit);
            }

            // Read operations continuously
            while (true)
            {
                string input = Console.ReadLine()!;

                // Stop if no input
                if (string.IsNullOrEmpty(input))
                    break;

                string[] parts = input.Split(' ');

                string operation = parts[0];

                // Withdraw
                if (operation == "Withdraw")
                {
                    double amount = double.Parse(parts[1]);

                    account.Withdraw(amount);
                }

                // Deposit
                else if (operation == "Deposit")
                {
                    double amount = double.Parse(parts[1]);

                    bool success = account.Deposit(amount);

                    if (success)
                    {
                        Console.WriteLine(
                            $"Deposit Successful,New Balance:{account.GetBalance()}"
                        );
                    }
                }

                // Get Balance
                else if (operation == "GetBalance")
                {
                    Console.WriteLine(
                        $"Current Balance: {account.GetBalance()}"
                    );
                }

                // Apply Interest
                else if (operation == "ApplyInterest"
                         && account is SavingsAccount savings)
                {
                    double rate = double.Parse(parts[1]);

                    savings.ApplyInterest(rate);
                }

                // Deduct Fee
                else if (operation == "DeductTransactionFee"
                         && account is CurrentAccount current)
                {
                    current.DeductTransactionFee();
                }
            }
        }
    }
}