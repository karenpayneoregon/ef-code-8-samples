/*
    .\SQLEXPRESS
    BookCatalog
*/
SELECT Id, 
       Title, 
       format(Price,'C2','en-US') Price,
       CASE
           WHEN Price < 10
           THEN 'Cheap'
           WHEN Price > 10 AND Price < 20
           THEN 'Medium'
           ELSE 'Expensive'
       END AS PriceRange
FROM dbo.book
WHERE Price IN
(
    SELECT Price
    FROM dbo.book
    GROUP BY Price
    HAVING COUNT(*) = 1
)
ORDER BY PriceRange