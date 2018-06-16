WITH CTE_CustomersCount (CustomerId, FeedbackCount) AS
(SELECT
   CustomerId AS [CustomerId],
   count(*)   AS [FeedbackCount]
 FROM Feedbacks
 GROUP BY CustomerId
 HAVING count(*) >= 3)

SELECT
  f.ProductId                          AS [ProductId],
  concat(c.FirstName, ' ', c.LastName) AS [CustomerName],
  isnull(f.Description, '')            AS [FeedbackDescription]
FROM cte_customerscount cte
  JOIN Customers c
    ON cte.CustomerId = c.Id
  JOIN Feedbacks f
    ON c.Id = f.CustomerId
ORDER BY f.ProductId, CustomerName, f.Id
