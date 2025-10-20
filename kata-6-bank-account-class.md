# Kata 6 - Bank Account

## Objectives

Create a bank account class which will have the methods for Deposit, Withdraw and GetBalance.

## Steps

### Step 1: Create a New .NET Console Application

1. Open a terminal and navigate to your working directory.

   ```bash
   mkdir -p _dev/kata-6-bank-account && cd _dev/kata-6-bank-account
   ```

2. Run the following command to create a new .NET console app:

   ```bash
    dotnet new console -n BankAccount
   ```

3. Navigate into the newly created project folder:

   ```bash
   cd BankAccount
   ```

4. Open the project in Visual Studio Code:

   ```bash
   code .
   ```

---

### Step 2: Implement the Bank Account Class

1. Create a new file named `BankAccount.cs` in the project directory.
2. Add the following code to implement the `BankAccount` class with `Deposit`, `Withdraw`, and `GetBalance` methods:

```csharp
using System;
public class BankAccount
{
    private decimal balance;

    public BankAccount()
    {
        balance = 0;
    }

    public void Deposit(decimal amount)
    {
        // Implement This Method

        // Hint: Increase the balance by the amount deposited
        // Hint: Ensure the amount is positive before adding to balance
        // Hint: Throw an exception or handle invalid amounts as needed
    }

    public void Withdraw(decimal amount)
    {
       // Implement This Method

       // Hint: Decrease the balance by the amount withdrawn
       // Hint: Ensure the amount is positive and does not exceed the current balance
       // Hint: Throw an exception or handle invalid amounts as needed
    }

    public decimal GetBalance()
    {
        // Implement This Method

         // Hint: Return the current balance


    }
}
```

### Step 3 - Implement class into Program.cs to test functionality:

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        account.Deposit(100);
        Console.WriteLine("Balance after depositing $100: " + account.GetBalance());

        account.Withdraw(30);
        Console.WriteLine("Balance after withdrawing $30: " + account.GetBalance());

        account.Withdraw(80);
        Console.WriteLine("Final Balance: " + account.GetBalance());
    }
}
```

### Step 4 - Run the Application

1. Open a terminal in the project directory.
2. Run the application using the following command:

   ```bash
   dotnet run
   ```

3. Observe the output to ensure the bank account functionality works as expected.

### Step 5 - Commit Your Changes

1. Initialise Git & commit your worked based on previous kata's.

## Completion Criteria

- A `BankAccount` class is created with methods for `Deposit`, `Withdraw`, and `GetBalance`.
- The application runs successfully, demonstrating the functionality of the bank account class.
- Proper error handling is implemented for invalid deposit and withdrawal amounts.
- Changes are committed to the Git repository.

## Stretch Goals

- Make the console applicaiton interactive, allowing users to input deposit and withdrawal amounts (via console) using Console.ReadLine().

## Resources

| Topic                    | Link                                                                         |
| ------------------------ | ---------------------------------------------------------------------------- |
| C# Classes and Objects   | https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/ |
| Exception Handling in C# | https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/ |
| C# Classes Documentation | https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes   |
