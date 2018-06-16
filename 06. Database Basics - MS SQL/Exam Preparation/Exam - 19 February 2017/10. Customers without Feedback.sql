SELECT
  concat(c.FirstName, ' ', c.LastName) AS [CustomerName],
  c.PhoneNumber,
  c.Gender
FROM Customers c
  LEFT JOIN Feedbacks f
    ON c.Id = f.CustomerId
WHERE f.Id IS NULL
ORDER BY c.Id
