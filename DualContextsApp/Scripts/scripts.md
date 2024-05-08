# Add NorthWind customer

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