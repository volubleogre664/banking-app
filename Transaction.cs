using System;

public class Transaction
{
    private DateTime TransactionDate;
    private decimal TransactionAmount;
    public TransactionType TransactionType;

    public Transaction(decimal amount, DateTime date, TransactionType type)
    {
        TransactionDate = date;
        TransactionAmount = amount;
        TransactionType = type;
    }

    public DateTime GetDate()
    {
        return TransactionDate;
    }

    public decimal GetAmount()
    {
        return TransactionAmount;
    }

    public TransactionType GetType()
    {
        return TransactionType;
    }

    public override string ToString()
    {
        return TransactionType.ToString().PadRight(10) + " | " 
        + TransactionAmount.ToString().PadRight(10) + " | " 
        + TransactionDate.ToString();
    }
}

public enum TransactionType
{
    Deposit,
    Withdrawal
}