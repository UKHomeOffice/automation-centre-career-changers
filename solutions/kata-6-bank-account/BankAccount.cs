namespace BankAccount;

public class BankAccount
{
    private decimal _balance;

    public BankAccount()
    {
        _balance = 0;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }
        if (amount > _balance)
        {
            throw new InvalidOperationException("Insufficient funds for this withdrawal.");
        }
        _balance -= amount;
    }

}