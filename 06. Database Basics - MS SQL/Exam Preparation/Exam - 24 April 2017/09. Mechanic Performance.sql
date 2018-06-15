SELECT
  m.FirstName + ' ' + m.LastName AS [Mechanic],
  avg(dayspermechanicid.Days)
FROM Mechanics AS m
JOIN (SELECT MechanicId , DATEDIFF(DAY, IssueDate, FinishDate) AS [Days]
      FROM Jobs
      WHERE Status = 'Finished'
    ) AS DaysPerMechanicId
  ON m.MechanicId = dayspermechanicid.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName, m.MechanicId
ORDER BY m.MechanicId