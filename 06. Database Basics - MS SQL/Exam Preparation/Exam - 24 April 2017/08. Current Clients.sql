SELECT
  c.FirstName + ' ' + c.LastName           AS [Client],
  datediff(DAY, j.IssueDate, '04/24/2017') AS [Day going],
  j.Status                                 AS [Status]
FROM Clients AS c
  JOIN Jobs j
    ON c.ClientId = j.ClientId
WHERE j.Status <> 'Finished'
ORDER BY [Day going] DESC, c.ClientId