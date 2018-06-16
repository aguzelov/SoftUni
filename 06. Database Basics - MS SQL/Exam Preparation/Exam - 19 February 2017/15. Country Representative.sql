SELECT CountryName, DistributorName
FROM (
  SELECT
    c.Name AS [CountryName],
    d.Name AS [DistributorName],
    COUNT(i.Id) AS [IngredientsCount],
    DENSE_RANK()
    OVER ( PARTITION BY c.Name
      ORDER BY count(i.Id) DESC ) AS Rank
  FROM Countries c
    JOIN Distributors d
      ON d.CountryId = c.Id
    JOIN Ingredients i
      ON i.DistributorId = d.Id
  GROUP BY c.Name, d.Name
) AS Ordered
WHERE ordered.rank = 1
ORDER BY CountryName, DistributorName
