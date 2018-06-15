SELECT m.FirstName + ' ' + m.LastName AS [Mechanic]
FROM Mechanics AS m
  JOIN (
    SELECT *
    FROM Mechanics
    WHERE MechanicId NOT IN (
      SELECT Jobs.MechanicId
      FROM Jobs
      WHERE Status <> 'Finished'
            AND Jobs.MechanicId IS NOT NULL
    )
    ) AS s ON s.MechanicId = m.MechanicId
