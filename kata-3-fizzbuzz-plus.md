# Kata 3 – FizzBuzz Plus in .NET 9

## Objective

Implement the FizzBuzz Plus problem in a .NET 9 console application. This kata will help you practice basic C# programming, loops, conditionals, and console I/O.

## Prerequisites

Before starting:

- Completion of **Kata 1 – Environment Setup**
- Completion of **Kata 2 – Git Basics**
- .NET 9 SDK installed and verified (`dotnet --version` to confirm)

## Steps

### Step 1: Create a New .NET Console Application

1. Open a terminal and navigate to your working directory.

   ```bash
   mkdir -p _dev/kata-3-fizzbuzz-plus && cd _dev/kata-3-fizzbuzz-plus
   ```

2. Run the following command to create a new .NET console app:

   ```bash
   dotnet new console -n FizzBuzzPlus
   ```

3. Navigate into the newly created project folder:

   ```bash
   cd FizzBuzzPlus
   ```

4. Open the project in Visual Studio Code:

   ```bash
   code .
   ```

---

### Step 2: Implement FizzBuzz Plus

1. Open the `Program.cs` file.
2. Replace the contents with the following code:

   ```csharp
   using System;

   class Program
   {
       static void Main(string[] args)
       {
           Console.WriteLine("Enter a number:");
           if (int.TryParse(Console.ReadLine(), out int number))
           {
               for (int i = 1; i <= number; i++)
               {
                   if (i % 3 == 0 && i % 5 == 0)
                   {
                       Console.WriteLine("FizzBuzz");
                   }
                   else if (i % 3 == 0)
                   {
                       Console.WriteLine("Fizz");
                   }
                   else if (i % 5 == 0)
                   {
                       Console.WriteLine("Buzz");
                   }
                   else
                   {
                       Console.WriteLine(i);
                   }
               }
           }
           else
           {
               Console.WriteLine("Invalid input. Please enter a valid number.");
           }
       }
   }
   ```

3. Save the file.

---

### Step 3: Run the Application

1. In the terminal, run the application:

   ```bash
   dotnet run
   ```

2. Test the application by entering different numbers and observing the output.

---

### Step 4: Commit Your Work

1. Initialize a Git repository (if not already done):

   ```bash
   git init
   ```

2. Add the files to the repository:

   ```bash
   git add .
   ```

3. Commit your changes:

   ```bash
   git commit -m "Implement FizzBuzz Plus"
   ```

4. Push to a remote repository:

   ```bash
   git remote add origin https://github.com/<username>/FizzBuzzPlus.git
   git branch -M main
   git push -u origin main
   ```

## Completion CriteriaÏ

- .NET 9 console app created
- FizzBuzz Plus logic implemented
- Application runs and produces correct output
- Code committed to Git repository

## Resources

https://www.geeksforgeeks.org/dsa/fizz-buzz-implementation/
