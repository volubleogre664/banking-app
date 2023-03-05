using System;
using System.Collections.Generic;

public class BankAccount
{
    private decimal Balance;
    private int AccountNumber;
    private List<Transaction> Transactions;

    public BankAccount(int accountNumber)
    {
        AccountNumber = accountNumber;
        Balance = 0;
        Transactions = new List<Transaction>();
    }

    public int GetAccountNumber()
    {
        return AccountNumber;
    }

    public decimal GetBalance()
    {
        return Balance;
    }

    public List<Transaction> GetTransactions()
    {
        return Transactions;
    }

    public string Deposit(decimal amount)
    {
        Balance += amount;
        Transactions.Add(new Transaction(amount, DateTime.Now, TransactionType.Deposit));

        return Transactions[Transactions.Count - 1].ToString();
    }

    public string Withdraw(decimal amount)
    {
        if (amount > Balance)
            throw new Exception("Insufficient funds.");

        if (amount <= 0)
            throw new Exception("Amount must be greater than zero.");

        Balance -= amount;
        Transactions.Add(new Transaction(amount, DateTime.Now, TransactionType.Withdrawal));
        return Transactions[Transactions.Count - 1].ToString();
    }

    public override string ToString()
    {
        return "" + AccountNumber.ToString().PadRight(14) + " | " 
        +  Balance.ToString().PadRight(7) + " | " 
        + Transactions.Count;
    }

    // Override the equeals method
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        return false;

        BankAccount account = obj as BankAccount;
        return AccountNumber == account.GetAccountNumber();
    }

    public override int GetHashCode()
    {
        return AccountNumber;
    }
}