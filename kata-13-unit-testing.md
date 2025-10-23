# Kata 13 – Unit Testing

## Objective

Learn the fundamentals of unit testing in C# using the NUnit framework. This kata will guide you through writing and executing unit tests to ensure your code behaves as expected.

Automated testing is a critical skill for any developer, ensuring that code changes do not introduce new bugs and that existing functionality remains intact.

## Prerequisites

Create a new WebAPI Project using .NET CLI or Visual Studio Code.

## Steps

### Step 1: Set Up NUnit

1. Add the NUnit and NUnit3TestAdapter packages to your project using the following commands:

   ```sh
   dotnet add package NUnit
   dotnet add package NUnit3TestAdapter
   dotnet add package Microsoft.NET.Test.Sdk
   ```

2. Create a new folder named `Tests` in your project directory.
3. Inside the `Tests` folder, create a new C# file named `CalculatorTests.cs`.

### Step 2: Write a Simple Class to Test

1. Create a new C# file named `Calculator.cs` in your main project directory with the following content:

   ```csharp
   public class Calculator
   {
       public int Add(int a, int b)
       {
           return a + b;
       }

       public int Subtract(int a, int b)
       {
           return a - b;
       }
   }
   ```

### Step 3: Write Unit Tests

Create a `CalculatorTests.cs` file in the `Tests` folder with the following content:

```csharp
using NUnit.Framework;

namespace Kata13UnitTesting.Tests;

public class CalculatorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Add_WhenCalledWithTwoIntegers_ReturnsTheirSum()
    {
        var calculator = new Calculator();
        var result = calculator.Add(2, 3);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Subtract_WhenCalledWithTwoIntegers_ReturnsTheirDifference()
    {
        var calculator = new Calculator();
        var result = calculator.Subtract(5, 3);
        Assert.That(result, Is.EqualTo(2));
    }

}
```

### Step 4: Run the Tests

1. Open a terminal in your project directory.
2. Run the tests using the following command:
   ```sh
   dotnet test
   ```
3. Verify that all tests pass successfully. It will show a test summary indicating the number of tests run and their results.

### Mocking Dependencies

1. If your class has dependencies, you can use a mocking framework like NSubstitute to create mock objects for testing.

2. Add the NSubstitute package to your project:

   ```sh
   dotnet add package NSubstitute
   ```

3. Create a new class `PassportRepository.cs` with a dependency on an interface `IDatabaseProvider`:

_This is all kept in a single file for simiplicity. Usually, you would separate these into different files._

You will see that PassportRepository depends on IDatabaseProvider. In your unit tests, you can create a mock of IDatabaseProvider to test PassportRepository in isolation. In a real application you would implement RealDatabaseProvider to interact with a real database and then mock this implementation in your tests.

```csharp

public class PassportRepository(IDatabaseProvider databaseProvider)
{
    private readonly IDatabaseProvider _databaseProvider = databaseProvider;

    public void SavePassport(Passport passport)
    {
        _databaseProvider.SavePassport(passport);
    }

    public Passport? GetPassportById(int id)
    {
        return _databaseProvider.GetPassportById(id);
    }
}

public class Passport
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}

public interface IDatabaseProvider
{
    void SavePassport(Passport passport);
    Passport? GetPassportById(int id);
}

public class RealDatabaseProvider : IDatabaseProvider
{
    private List<Passport> _passports = new List<Passport>()
    {
        new Passport { Id = 1, Name = "Alice Smith", DateOfBirth = new DateTime(1990, 1, 1) },
        new Passport { Id = 2, Name = "Bob Johnson", DateOfBirth = new DateTime(1985, 5, 15) },
        new Passport { Id = 3, Name = "Charlie Brown", DateOfBirth = new DateTime(1978, 12, 30) },
        new Passport { Id = 4, Name = "Diana Prince", DateOfBirth = new DateTime(1992, 7, 4) },
        new Passport { Id = 5, Name = "Ethan Hunt", DateOfBirth = new DateTime(1983, 3, 21) },
    };

    public void SavePassport(Passport passport)
    {
        // Real database save logic
        _passports.Add(passport);
    }

    public Passport? GetPassportById(int id)
    {
        // Real database retrieval logic
        return _passports.FirstOrDefault(p => p.Id == id);
    }
}
```

### Step 5: Write Unit Tests with Mocks

Create a `PassportRepositoryTests.cs` file in the `Tests` folder with the following content:

```csharp
using NSubstitute;
using NUnit.Framework;

namespace Kata13UnitTesting.Tests;

public class PassportRepositoryTests
{
    [SetUp]
    public void Setup()
    {
    }

    private readonly IDatabaseProvider _databaseProvider = Substitute.For<IDatabaseProvider>();


    [Test]
    public void GetPassportById_WhenCalled_ReturnsPassportFromDatabaseProvider()
    {
        // Arrange
        var expectedPassport = new Passport { Id = 1, Name = "John Doe" };
        _databaseProvider.GetPassportById(1).Returns(expectedPassport);
        var repository = new PassportRepository(_databaseProvider);

        // Act
        var result = repository.GetPassportById(1);

        // Assert
        Assert.That(result?.Id, Is.EqualTo(1));
        Assert.That(result?.Name, Is.EqualTo("John Doe"));
    }

    [Test]
    public void SavePassport_WhenCalled_InvokesDatabaseProviderSavePassport()
    {
        // Arrange
        var passportToSave = new Passport { Id = 2, Name = "Jane Doe" };
        var repository = new PassportRepository(_databaseProvider);

        // Act
        repository.SavePassport(passportToSave);

        // Assert
        _databaseProvider.Received(1).SavePassport(passportToSave);


    }
}
```

In this context we create a mock of `IDatabaseProvider` using NSubstitute and configure it to return a specific `Passport` when `GetPassportById` is called. For example:

`_databaseProvider.GetPassportById(Arg.Any<int>()).Returns(expectedPassport);`

This ensures the test is independent of any real database implementation. The test then constructs a `PassportRepository` with the mocked provider, calls `GetPassportById`, and asserts the returned `Passport` equals `expectedPassport`.

In the real database, ID 1 is for "Alice Smith", but our mock returns "John Doe", demonstrating how mocking allows us to control dependencies in unit tests.

We do this to completely isolate the unit of work we are testing (PassportRepository) from its dependencies (IDatabaseProvider), which will allow us to specifically test code within the Passport Repositor without worrying about the behaviour of external dependencies.

## Additional Exercises

- Write additional tests for the PassportRepository class, such as testing the `SavePassport` method.

## Useful Resources

- [NUnit Documentation](https://nunit.org/)
- [NSubstitute Documentation](https://nsubstitute.github.io/)
