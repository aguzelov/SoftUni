SELECT ISNULL(SUM(p.Price * part.Quantity),0) AS [Parts Total]
FROM Orders AS o
  JOIN OrderParts part ON o.OrderId = part.OrderId
  JOIN Parts p ON part.PartId = p.PartId
WHERE o.IssueDate > (DATEADD(WEEK, -3 , '2017/04/24'))