using ShadowProperties.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
#pragma warning disable CS0169

namespace ShadowProperties.Models;

[Table("Contact1")]
public partial class Contact : INotifyPropertyChanged, IShadows
{
    private int _contactId;
    private string _firstName;
    private string _lastName;

    [Display(Name = "Id")]
    public int ContactId
    {
        get => _contactId;
        set
        {
            _contactId = value;
            OnPropertyChanged();
        }
    }
    [Display(Name = "First")]
    public string FirstName
    {
        get => _firstName;
        set
        {
            _firstName = value;
            OnPropertyChanged();
        }
    }
    [Display(Name = "Last")]
    public string LastName
    {
        get => _lastName;
        set
        {
            _lastName = value;
            OnPropertyChanged();
        }
    }

    public Contact(int id)
    {
        ContactId = id;
    }

    public Contact()
    {
            
    }

    [NotMapped]
    [Display(Name = "Deleted")]
    public bool isDeleted { get; set; }
    public override string ToString() => $"{FirstName} {LastName}";

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}