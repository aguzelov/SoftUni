SELECT TOP 1 WITH TIES
  c2.Name     AS [CountryName],
  avg(f.Rate) AS [FeedbackRate]
FROM Feedbacks AS f
  JOIN Customers c
    ON f.CustomerId = c.Id
  JOIN Countries c2
    ON c.CountryId = c2.Id
GROUP BY c2.Name
ORDER BY FeedbackRate DESC