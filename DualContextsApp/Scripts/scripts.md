# Add NorthWind customer

## EF

```sql
USE [NorthWind2024]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AddCustomer]
(
	@Identifier INT = NULL OUTPUT, 
    @CompanyName AS NVARCHAR(40),
    @ContactId AS INT,
    @Street AS NVARCHAR(60),
    @City AS NVARCHAR(15),
    @Region AS NVARCHAR(15),
    @PostalCode AS NVARCHAR(10),
    @CountryIdentifier AS INT,
    @Phone AS NVARCHAR(24),
    @ContactTypeIdentifier AS INT
)
AS
BEGIN
    INSERT INTO dbo.Customers
    (
        CompanyName,
        ContactId,
        Street,
        City,
        Region,
        PostalCode,
        CountryIdentifier,
        Phone,
        ContactTypeIdentifier
    )
    VALUES
    (@CompanyName, @ContactId, @Street, @City, @Region, @PostalCode, @CountryIdentifier, @Phone, @ContactTypeIdentifier);
	SET @Identifier = @@IDENTITY
END;


```

## Dapper

```sql
USE [NorthWind2024]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_AddCustomer1]
(
    @CompanyName AS NVARCHAR(40),
    @ContactId AS INT,
    @Street AS NVARCHAR(60),
    @City AS NVARCHAR(15),
    @Region AS NVARCHAR(15),
    @PostalCode AS NVARCHAR(10),
    @CountryIdentifier AS INT,
    @Phone AS NVARCHAR(24),
    @ContactTypeIdentifier AS INT
)
AS
BEGIN
    INSERT INTO dbo.Customers
    (
        CompanyName,
        ContactId,
        Street,
        City,
        Region,
        PostalCode,
        CountryIdentifier,
        Phone,
        ContactTypeIdentifier
    )
    VALUES
    (@CompanyName, @ContactId, @Street, @City, @Region, @PostalCode, @CountryIdentifier, @Phone, @ContactTypeIdentifier);
	SELECT CAST(SCOPE_IDENTITY() AS INT);
END;

GO
```

## Wrong and Right

```csharp
public static async Task NorthAddCustomer()
{
    NorthModels.Customer cust = new()
    {
        CompanyName = "New Customer",
        ContactId = 1,
        Street = "123 Main St",
        City = "New York",
        Region = "NY",
        PostalCode = "10001",
        CountryIdentifier = 1,
        Phone = "123-456-7890",
        Fax = "987-654-3210",
        ContactTypeIdentifier = 1,
        ModifiedDate = DateTime.Now
    };

    await using var context = new NorthContext();
    var affected = await context.Database.ExecuteSqlAsync(
        $"""
            EXEC dbo.usp_AddCustomer
            @CompanyName = {cust.CompanyName},
            @ContactId = {cust.ContactId},
            @Street = {cust.Street},
            @City = {cust.City},
            @Region = {cust.Region},
            @PostalCode = {cust.PostalCode},
            @CountryIdentifier = {cust.CountryIdentifier},
            @Phone = {cust.Phone},
            @ContactTypeIdentifier = {cust.ContactTypeIdentifier}
            """);
    
    
        
}



public static async Task NorthAddCustomerDapper1()
{

    NorthModels.Customer cust = new()
    {
        CompanyName = "New Customer",
        ContactId = 1,
        Street = "123 Main St",
        City = "New York",
        Region = "NY",
        PostalCode = "10001",
        CountryIdentifier = 9,
        Phone = "123-456-7890",
        Fax = "987-654-3210",
        ContactTypeIdentifier = 3
    };


    await using var cn = new SqlConnection(Instance.SecondaryConnection);
    var id = await cn.ExecuteScalarAsync<int>("dbo.usp_AddCustomer1", 
        new
        {
            cust.CompanyName,
            cust.ContactId,
            cust.Street,
            cust.City,
            cust.Region,
            cust.PostalCode,
            cust.CountryIdentifier,
            cust.Phone,
            cust.ContactTypeIdentifier
        }, commandType: CommandType.StoredProcedure);


    cust.CustomerIdentifier = id;
}
```