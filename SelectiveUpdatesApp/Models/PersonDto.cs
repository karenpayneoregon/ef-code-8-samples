namespace SelectiveUpdatesApp.Models;

/// <summary>
/// Represents a data transfer object for a person, containing properties such as title, first name, last name, and birth date.
/// </summary>
public class PersonDto
{
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
}