WITH cte_SingleDist (ProductId) AS
(SELECT p.Id
 FROM Products p
   JOIN ProductsIngredients pro
     ON p.Id = pro.ProductId
   JOIN Ingredients i
     ON pro.IngredientId = i.Id
   JOIN Distributors AS d
     ON i.DistributorId = d.Id
 GROUP BY p.Id
 HAVING count(DISTINCT d.Id) = 1)

SELECT
  ProductName,
  AverageRate,
  DistributorName,
  DistributorCountry
FROM (
       SELECT
         p.Name      AS [ProductName],
         avg(f.Rate) AS [AverageRate],
         d.Name      AS [DistributorName],
         c.Name      AS [DistributorCountry]
       FROM cte_singledist s
         JOIN Products p
           ON s.ProductId = p.Id
         JOIN ProductsIngredients pro
           ON p.Id = pro.ProductId
         JOIN Ingredients i
           ON pro.IngredientId = i.Id
         JOIN Distributors d
           ON i.DistributorId = d.Id
         JOIN Countries c
           ON d.CountryId = c.Id
         JOIN Feedbacks f
           ON p.Id = f.ProductId
       GROUP BY p.Name, d.Name, c.Name) AS Result
  JOIN Products p2
    ON result.ProductName = p2.Name
ORDER BY p2.Id