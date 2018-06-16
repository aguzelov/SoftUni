SELECT
  f.ProductId,
  f.Rate,
  f.Description,
  c.Id,
  c.Age,
  c.Gender
FROM Feedbacks f
  JOIN Customers c
    ON f.CustomerId = c.Id
WHERE f.Rate < 5
ORDER BY f.ProductId DESC, f.Rate