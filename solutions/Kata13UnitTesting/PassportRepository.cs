using System;

namespace Kata13UnitTesting;

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