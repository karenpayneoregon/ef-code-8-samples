using Bogus;
using Bogus.Extensions.UnitedStates;

namespace EF_Core_MaskingSample.Classes;

public static class BogusOperations
{
    public static List<Models.Person> CreatePeople()
    {
        var personFaker = new Faker<Models.Person>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.BirthDate, f => DateOnly.FromDateTime(f.Date.Past(40, DateTime.Today.AddYears(-18))))
            .RuleFor(p => p.SocialSecurity, f => f.Person.Ssn())
            .RuleFor(p => p.CreditCard, f => f.Finance.CreditCardNumber().Replace("-", ""));

        return personFaker.Generate(20);
    }
}
