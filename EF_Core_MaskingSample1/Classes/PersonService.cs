using System;
using EF_Core_MaskingSample.Data;
using EF_Core_MaskingSample1.Models;

namespace EF_Core_MaskingSample1.Classes;

public class PersonService
{
    private readonly Context _dbContext;
    private readonly EncryptionService _encryptionService;

    public PersonService(Context dbContext, EncryptionService encryptionService)
    {
        _dbContext = dbContext;
        _encryptionService = encryptionService;
    }

    public async Task CreatePersonAsync(PersonDto dto)
    {
        var person = new Person
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            CreditCard = dto.CreditCard
        };

        person.EncryptCreditCard(_encryptionService);
        await _dbContext.Person.AddAsync(person);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PersonDto> GetPersonAsync(int id)
    {
        var person = await _dbContext.Person.FindAsync(id);
        if (person == null)
            return null;

        person.DecryptCreditCard(_encryptionService);

        return new PersonDto
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            CreditCard = person.MaskedCreditCard
        };
    }
}
