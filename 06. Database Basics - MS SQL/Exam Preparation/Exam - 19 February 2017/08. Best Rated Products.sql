SELECT TOP (10)
  p.Name,
  p.Description,
  avg(f.Rate) AS [AverageRate],
  count(*)    AS [FeedbacksAmount]
FROM Products p
  JOIN Feedbacks f
    ON p.Id = f.ProductId
GROUP BY p.Name, p.Description
ORDER BY avg(f.Rate) DESC, count(*) DESC
