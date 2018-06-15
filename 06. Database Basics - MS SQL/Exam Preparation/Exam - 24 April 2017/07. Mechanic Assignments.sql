SELECT
  m.FirstName + ' ' + m.LastName AS [Mechanic],
  j.Status                       AS [Status],
  j.IssueDate                    AS [IssueDate]
FROM Mechanics AS m
  JOIN Jobs j
    ON m.MechanicId = j.MechanicId
ORDER BY j.MechanicId, IssueDate, JobId