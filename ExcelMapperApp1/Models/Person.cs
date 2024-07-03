using Ganss.Excel;

namespace ExcelMapperApp1.Models;
/// <summary>
/// Models for reading a row of data from Excel and return Person and Address
/// Note the column attribute to map the Excel column name to the property name
/// </summary>
public class Person
{
    [Column("First Name")]
    public string FirstName { get; set; }
    [Column("Last Name")]
    public string LastName { get; set; }
    [Column("Birth Date")]
    public DateOnly BirthDate { get; set; }
    public Address Address { get; set; }
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
}
