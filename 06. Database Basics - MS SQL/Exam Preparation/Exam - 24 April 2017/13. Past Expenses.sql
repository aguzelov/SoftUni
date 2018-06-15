SELECT
  j.JobId                               AS [Job ID],
  isnull(sum(p.Price * op.Quantity), 0) AS [Total]
FROM Jobs AS j
  FULL JOIN Orders AS o
    ON j.JobId = o.JobId
  FULL JOIN OrderParts AS op
    ON op.OrderId = o.OrderId
  FULL JOIN Parts AS p
    ON op.PartId = p.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, [Job ID] ASC