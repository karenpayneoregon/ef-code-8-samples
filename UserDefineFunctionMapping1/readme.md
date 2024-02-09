# User-defined function mapping

EF Core allows for using user-defined SQL functions in queries. To do that, the functions need to be mapped to a CLR method during model configuration. When translating the LINQ query to SQL, the user-defined function is called instead of the CLR function it has been mapped to.

*From Microsoft*

[Microsoft docs](https://learn.microsoft.com/en-us/ef/core/querying/user-defined-function-mapping)

In this project the following function 

```sql
CREATE FUNCTION [dbo].[ConcatStrings] (@prm1 nvarchar(max), @prm2 nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
    RETURN @prm1 + @prm2;
END
```

Is mapped to the following two methods which are never called

```csharp
public string ConcatStrings(string prm1, string prm2)
    => throw new InvalidOperationException();

public string ConcatStringsOptimized(string prm1, string prm2)
    => throw new InvalidOperationException();
```

Setup in our DbContext

```csharp
public string ConcatStrings(string prm1, string prm2)
    => throw new InvalidOperationException();
public string ConcatStringsOptimized(string prm1, string prm2)
    => throw new InvalidOperationException();
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<ContactType>(entity =>
    {
        entity.HasKey(e => e.ContactTypeIdentifier);
    });

    modelBuilder
        .HasDbFunction(typeof(Context).GetMethod(nameof(ConcatStrings), new[] { typeof(string), typeof(string) }))
        .HasName("ConcatStrings");

    modelBuilder.HasDbFunction(
        typeof(Context).GetMethod(nameof(ConcatStringsOptimized), new[] { typeof(string), typeof(string) }),
        b =>
        {
            b.HasName("ConcatStrings");
            b.HasParameter("prm1").PropagatesNullability();
            b.HasParameter("prm2").PropagatesNullability();
        });
```

## Usage

Here there are 91 contacts, the following excludes one contact so we get 90 contacts.

```csharp
internal partial class Program
{
    static void Main(string[] args)
    {

        using var context = new Context();
        string excludeThisContact = "Patricio Simpson";
        List<Contacts> list = context
            .Contacts
            .Include(c => c.ContactTypeIdentifierNavigation)
            .Where(c => context.ConcatStrings(c.FirstName, c.LastName) != excludeThisContact)
            .ToList();
    }
}
```

Generated SQL

```sql
SELECT [c].[ContactId], 
	 [c].[ContactTypeIdentifier], 
	 [c].[FirstName], 
	 [c].[FullName], 
	 [c].[LastName], 
	 [c0].[ContactTypeIdentifier], 
	 [c0].[ContactTitle]
FROM [Contacts] AS [c]
LEFT JOIN [ContactType] AS [c0] ON [c].[ContactTypeIdentifier] = [c0].[ContactTypeIdentifier]
WHERE [dbo].[ConcatStrings]([c].[FirstName], [c].[LastName]) <> 
     @__excludeThisContact_1 OR [dbo].[ConcatStrings]([c].[FirstName], [c].[LastName]) IS NULL
```
