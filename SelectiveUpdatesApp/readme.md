# EF Core: Update selected properties for a record

![Data Updates](assets/DataUpdates.png)

When a developer **does not** want to update an entire record which has been modified there are two options.

## Option 1

As shown below, set the property (or properties) that a developer wants to be updated with `.IsModified = false` as per below for `FirstName` property.

Simple example that reads a record, makes changes which since change tracker is tracking the entity on save all changed properties are sent to the database but in this example we mark `context.Entry(person).Property(p => p.LastName).IsModified = false;` to not send changes for LastName to the database, only FirstName.


```csharp
using var context = new Context();
var person = context.Person.FirstOrDefault();

if (person is not null)
{
    person.FirstName = "James";
    person.LastName = "Adams";
    context.Entry(person).State = EntityState.Modified;
    context.Entry(person).Property(p => p.LastName).IsModified = false;
    context.SaveChanges();
}
```

## Option 2

In this option we create a DTO (Data Transer Object)

```csharp
public class PersonModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
}
```

Based from the `DbSet`

```csharp
public partial class Person
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
}
```

- Identify the record by primary key, in this case `2`
- Create a new instance of the model, in this case `Person`
- Create an instance of the DTO, set the `Id` property to (in this case) to `2`
- Attach the new instance in bullet two to the DbContext
- Set the values for the new instance of Person from the DTO
- Save changes back to the database

```csharp
    using Context context = new ();
    int identifier = 2;
    Person person = new () { Id = identifier };
    PersonModel model = new() { Id = identifier, FirstName = "Kate" };

    context.Attach(person);
    context.Entry(person).CurrentValues.SetValues(model);
    context.SaveChanges();
```


> **Note**
> After executing the code, review the logging in Visual Studio Output window to see the UPDATE statement. Also, take time to run the code through Visual Studio's debugger by setting breakpoints to better understand what the code is doing rather than copy-n-pasting into one of your projects.

# Requires

- Microsoft Visual Studio 2022 or higher
- .NET Core 6 or higher
- Suggest SSMS (SQL-Server Management Studio) for data inspection