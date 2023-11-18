SELECT c.Id,
       c.Name,
       c.Address_City,
       c.Address_Country,
       c.Address_Line1,
       c.Address_Line2,
       c.Address_PostCode,
       o.Contents,
       o.BillingAddress_City
FROM dbo.Customers AS c
    INNER JOIN dbo.Orders AS o
        ON c.Id = o.CustomerId;