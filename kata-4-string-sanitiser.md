# Kata 4 – String Sanitiser

## Objective

Implement a method `SanitiseInput(string input)` in C# that performs the following operations:

1. Removes all punctuation.
2. Trims leading and trailing whitespace.
3. Converts the string to lowercase.
4. Collapses multiple spaces into a single space.

This kata will help you practice string manipulation, regular expressions, and basic C# programming.

---

## Steps

### Step 1: Create a New .NET Console Application

1. Open a terminal and navigate to your working directory.


   ```bash
   mkdir -p _dev/kata-4-string-sanitiser && cd _dev/kata-4-string-sanitiser
   ```

2. Run the following command to create a new .NET console app:

   ```bash
   dotnet new console -n StringSanitiser
   ```

3. Navigate into the newly created project folder:

   ```bash
   cd StringSanitiser
   ```

4. Open the project in Visual Studio Code:

   ```bash
   code .
   ```

---

### Step 2: Implement the `SanitiseInput` Method

1. Open the `Program.cs` file.
2. Replace the contents with the following code:

   ```csharp
   using System;
   using System.Text.RegularExpressions;

   class Program
   {
       static void Main(string[] args)
       {
           Console.WriteLine("Enter a string to Sanitise:");
           string input = Console.ReadLine();
           string sanitised = SanitiseInput(input);
           Console.WriteLine("Sanitised string:");
           Console.WriteLine(sanitised);
       }

       static string SanitiseInput(string input)
       {
           if (string.IsNullOrWhiteSpace(input))
           {
               return string.Empty;
           }
           
           // Remove punctuation
           input = Regex.Replace(input, "[\\p{P}-[']]+", "");

           // Trim whitespace
           input = input.Trim();

           // Convert to lowercase
           input = input.ToLower();

           // Collapse multiple spaces into one
           input = Regex.Replace(input, "\\s+", " ");
           
           return input;
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

2. Test the application by entering various strings and observing the Sanitised output.

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
   git commit -m "Implement String Sanitiser."
   ```

4. Push to a remote repository (if applicable):

   ```bash
   git remote add origin https://github.com/<username>/StringSanitiser.git
   git branch -M main
   git push -u origin main
   ```

---

## Completion Criteria

- .NET 9 console app created
- `SanitiseInput` method implemented
- Application runs and produces correct output
- Code committed to Git repository

---

## Resources

| Topic                    | Link                                                                                                                           |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------ |
| C# String Programming    | [https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/) |
| Regex in .NET            | [https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex) |
| Regular Expressions Quick Start | [https://www.regular-expressions.info/quickstart.html](https://www.regular-expressions.info/quickstart.html) |


