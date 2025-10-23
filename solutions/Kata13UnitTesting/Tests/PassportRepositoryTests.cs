using NSubstitute;
using NUnit.Framework;

namespace Kata13UnitTesting.Tests;

public class PassportRepositoryTests
{
    private readonly IDatabaseProvider _databaseProvider = Substitute.For<IDatabaseProvider>();

    [SetUp]
    public void Setup()
    {

    }

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
    public void GetPassportById_WhenCalled_CallsDatabaseProviderGetPassportById()
    {
        // Arrange
        var repository = new PassportRepository(_databaseProvider);
        var passportId = 3;
        // Act
        repository.GetPassportById(passportId);
        // Assert
        _databaseProvider.Received(1).GetPassportById(passportId);
    }

    [Test]
    public void GetPassportById_WhenCalled_ReturnsNullIfNotFound()
    {
        // Arrange
        var repository = new PassportRepository(_databaseProvider);
        var passportId = 999;

        // Act
        var result = repository.GetPassportById(passportId);

        // Assert
        Assert.That(result, Is.Null);
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
