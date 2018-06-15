WITH CTE_MaxModel (ModelId, Name, MaxCount) AS
(
    SELECT
      modelscount.ModelId,
      modelscount.Name,
      Count
    FROM (SELECT
            m.ModelId,
            m.Name,
            count(j.JobId) AS [Count]
          FROM Jobs AS j
            JOIN Models m
              ON j.ModelId = m.ModelId
          GROUP BY m.ModelId, m.Name
         ) AS modelsCount
    WHERE modelscount.Count = (SELECT TOP (1) count(j.JobId) AS [Count]
                               FROM Jobs AS j
                                 JOIN Models m
                                   ON j.ModelId = m.ModelId
                               GROUP BY m.ModelId
                               ORDER BY Count DESC))

SELECT
  maxmodel.Name                         AS [Model],
  maxmodel.MaxCount                     AS [Times Serviced],
  isnull(sum(p.Price * part.Quantity), 0) AS [Parts Total]
FROM cte_maxmodel AS maxmodel
  LEFT JOIN Jobs j
    ON j.ModelId = maxmodel.ModelId
  LEFT JOIN Orders o
    ON j.JobId = o.JobId
  LEFT JOIN OrderParts part
    ON o.OrderId = part.OrderId
  LEFT JOIN Parts p ON part.PartId = p.PartId
GROUP BY maxmodel.Name, maxmodel.MaxCount

/*
SELECT TOP 1 WITH TIES
  m.Name,
  COUNT(*)                      AS [Times Serviced],
  (SELECT ISNULL(SUM(p.Price * op.Quantity), 0)
   FROM Jobs AS j
     JOIN Orders AS o
       ON O.JobId = j.JobId
     JOIN OrderParts AS op
       ON op.OrderId = o.OrderId
     JOIN Parts AS p
       ON p.[PartId] = op.PartId
   WHERE j.ModelId = m.ModelId) AS [Parts Total]
FROM Models AS m
  JOIN Jobs AS j
    ON j.ModelId = m.ModelId
GROUP BY m.ModelId, m.Name
ORDER BY [Times Serviced] DESC*
*/