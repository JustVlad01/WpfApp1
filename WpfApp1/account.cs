using System;

public abstract class Account
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Balance { get; protected set; }
    public DateTime InterestDate { get; protected set; }

    public Account(string firstName, string lastName, decimal balance)
    {
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
        InterestDate = DateTime.Now;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
        }
    }

    public abstract void CalculateInterest();
}

public class CurrentAccount : Account
{
    public decimal InterestRate { get; }

    public CurrentAccount(string firstName, string lastName, decimal balance)
        : base(firstName, lastName, balance)
    {
        InterestRate = 0.03m; // 3% interest rate for current account
    }

    public override void CalculateInterest()
    {
        // Implement the calculation logic for current account interest here
        // For example:
        decimal interestAmount = Balance * InterestRate;
        Balance += interestAmount;
        InterestDate = DateTime.Now;
    }
}

public class SavingsAccount : Account
{
    public decimal InterestRate { get; }

    public SavingsAccount(string firstName, string lastName, decimal balance)
        : base(firstName, lastName, balance)
    {
        InterestRate = 0.06m; // 6% interest rate for savings account
    }

    public override void CalculateInterest()
    {
        // Implement the calculation logic for savings account interest here
        // For example:
        decimal interestAmount = Balance * InterestRate;
        Balance += interestAmount;
        InterestDate = DateTime.Now;
    }
}
