#nullable disable
namespace CreateAndPopulateSqlServerApp.Models;

public partial class Contacts
{
    public int ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string ToString() => $"{FirstName} {LastName}";

    public int? ContactTypeIdentifier { get; set; }

    public virtual ContactType ContactTypeNavigation { get; set; }

        
}