
/*9.Abstract Methods and Concrete Methods*/
using System;
abstract class Transaction
{
    public abstract void Execute();
    public void LogTransaction()
    {
        Console.WriteLine("Logging transaction...");
    }
}

class Deposit : Transaction
{
    public decimal Amount { get; set; }

    public Deposit(decimal amount)
    {
        Amount = amount;
    }

    public override void Execute()
    {
        Console.WriteLine($"Depositing {Amount}");
    }
}

class Withdrawal : Transaction
{
    public decimal Amount { get; set; }

    public Withdrawal(decimal amount)
    {
        Amount = amount;
    }

    public override void Execute()
    {
        Console.WriteLine($"Withdrawing {Amount}");
    }
}

class Program
{
    static void Main()
    {
        Transaction deposit = new Deposit(1000);
        deposit.Execute(); // Output: Depositing 1000
        deposit.LogTransaction(); // Output: Logging transaction...

        Transaction withdrawal = new Withdrawal(500);
        withdrawal.Execute(); // Output: Withdrawing 500
        withdrawal.LogTransaction(); // Output: Logging transaction...
    }
}
