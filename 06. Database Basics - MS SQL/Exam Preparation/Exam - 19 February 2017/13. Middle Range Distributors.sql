SELECT
  d.Name,
  i.Name,
  p.Name,
  avg(f.Rate)
FROM Feedbacks AS f
  JOIN Products AS p
    ON f.ProductId = p.Id
  JOIN ProductsIngredients AS pp
    ON p.Id = pp.ProductId
  JOIN Ingredients i
    ON pp.IngredientId = i.Id
  JOIN Distributors d
    ON i.DistributorId = d.Id
GROUP BY d.Name, i.Name, p.Name
HAVING avg(f.Rate) BETWEEN 5 AND 8
ORDER BY d.Name, i.Name, p.Name
