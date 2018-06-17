delete FROM Locations
WHERE Id IN (
  SELECT l.Id
  FROM Locations l LEFT JOIN Users u ON l.Id = u.LocationId
  WHERE u.Id IS NULL
)