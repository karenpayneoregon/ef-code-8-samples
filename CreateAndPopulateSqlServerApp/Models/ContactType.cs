#nullable disable
namespace CreateAndPopulateSqlServerApp.Models;

public partial class ContactType
{
    public ContactType()
    {
        Contacts = new HashSet<Contacts>();

    }

    public int ContactTypeIdentifier { get; set; }
    public string ContactTitle { get; set; }

    public virtual ICollection<Contacts> Contacts { get; set; }
    public override string ToString() => ContactTitle;

}