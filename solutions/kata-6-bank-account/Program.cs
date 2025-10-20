namespace BankAccount;

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        Console.WriteLine($"Initial Balance: {account.GetBalance()}");

        while (true)
        {
            Console.WriteLine("\nChoose an action: deposit (D), withdraw (W), balance (B), exit (E)");
            string? action = Console.ReadLine()?.Trim().ToLower();

            try
            {
                if (action == "d")
                {
                    Console.Write("Enter amount to deposit: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                    {
                        account.Deposit(depositAmount);
                        Console.WriteLine($"Balance after depositing {depositAmount}: {account.GetBalance()}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                }
                else if (action == "w")
                {
                    Console.Write("Enter amount to withdraw: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                    {
                        account.Withdraw(withdrawAmount);
                        Console.WriteLine($"Balance after withdrawing {withdrawAmount}: {account.GetBalance()}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                }
                else if (action == "b")
                {
                    Console.WriteLine($"Current Balance: {account.GetBalance()}");
                }
                else if (action == "e")
                {
                    Console.WriteLine($"Final Balance: {account.GetBalance()}");
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown action. Please try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
