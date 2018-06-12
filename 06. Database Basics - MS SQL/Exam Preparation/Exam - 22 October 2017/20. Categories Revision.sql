SELECT
  c.Name   AS [Category Name],
  count(1) AS [Reports Number],
  CASE
  WHEN InProgressCount > WaitingCount
    THEN 'in progress'
  WHEN InProgressCount < WaitingCount
    THEN 'waiting'
  ELSE 'equal'
  END      AS [MainStatus]
FROM Categories AS c
  JOIN Reports AS r
    ON c.Id = r.CategoryId
  JOIN Status AS s
    ON r.StatusId = s.Id
  JOIN (SELECT
          r.CategoryId,
          sum(CASE WHEN s.Label = 'in progress'
            THEN 1
              ELSE 0
              END) AS InProgressCount,
          sum(CASE WHEN s.Label = 'waiting'
            THEN 1
              ELSE 0
              END) AS WaitingCount
        FROM Reports AS r
          JOIN Status AS s
            ON r.StatusId = s.Id
        WHERE Label IN ('waiting', 'in progress')
        GROUP BY r.CategoryId
       ) AS sc
    ON sc.CategoryId = c.Id
WHERE r.StatusId IN (
  SELECT Status.Id
  FROM Status
  WHERE Label IN ('waiting', 'in progress')
)
GROUP BY c.Name,
  CASE
  WHEN InProgressCount > WaitingCount
    THEN 'in progress'
  WHEN InProgressCount < WaitingCount
    THEN 'waiting'
  ELSE 'equal'
  END
ORDER BY [Category Name], [Reports Number], [MainStatus]