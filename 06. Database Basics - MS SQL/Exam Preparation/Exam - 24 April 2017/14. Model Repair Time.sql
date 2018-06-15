SELECT
  m.ModelId                                                                   AS [ModelId],
  m.Name                                                                      AS [Name],
  cast(avg(datediff(DAY, j.IssueDate, j.FinishDate)) AS VARCHAR(5)) + ' days' AS [Average Service Time]
FROM Jobs AS j
  JOIN Models m
    ON j.ModelId = m.ModelId
WHERE j.Status = 'Finished'
GROUP BY m.Name, m.ModelId
ORDER BY avg(datediff(DAY, j.IssueDate, j.FinishDate))