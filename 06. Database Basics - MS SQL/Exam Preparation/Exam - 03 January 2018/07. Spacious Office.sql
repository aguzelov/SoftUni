SELECT
  t.Name          AS [TownName],
  o.Name          AS [OfficeName],
  o.ParkingPlaces AS [ParkingPlaces]
FROM Offices AS o
  JOIN Towns AS t
    ON o.TownId = t.Id
WHERE ParkingPlaces > 25
ORDER BY t.Name ASC, o.Id ASC