using System;
using EF_Core_MaskingSample.Data;
using EF_Core_MaskingSample1.Models;

namespace EF_Core_MaskingSample1.Classes;

public class PersonService
{
    private readonly Context _dbContext;
    private readonly EncryptionService _encryptionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonService"/> class.
    /// </summary>
    /// <param name="dbContext">
    /// The database context used to interact with the database.
    /// </param>
    /// <param name="encryptionService">
    /// The encryption service used for encrypting and decrypting sensitive data.
    /// </param>
    public PersonService(Context dbContext, EncryptionService encryptionService)
    {
        _dbContext = dbContext;
        _encryptionService = encryptionService;
    }

    /// <summary>
    /// Creates a new person record in the database with the provided details.
    /// </summary>
    /// <param name="dto">
    /// A <see cref="PersonDto"/> containing the details of the person to be created, 
    /// including their first name, last name, and credit card information.
    /// </param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// </returns>
    /// <remarks>
    /// This method encrypts the credit card information before saving the person record 
    /// to the database to ensure sensitive data is securely stored.
    /// </remarks>
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

    /// <summary>
    /// Retrieves a person's details by their unique identifier.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the person to retrieve.
    /// </param>
    /// <returns>
    /// A <see cref="PersonDto"/> containing the person's details, including their masked credit card information,
    /// or <c>null</c> if no person with the specified identifier is found.
    /// </returns>
    /// <remarks>
    /// This method fetches the person's data from the database, decrypts their credit card information,
    /// and returns a data transfer object with the masked credit card details.
    /// </remarks>
    public async Task<PersonDto> GetPersonAsync(int id)
    {
        var person = await _dbContext.Person.FindAsync(id);
        if (person == null)
            return null!;

        person.DecryptCreditCard(_encryptionService);

        return new PersonDto
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            CreditCard = person.MaskedCreditCard
        };
    }
}
