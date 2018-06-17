WITH CTE_C (ReturnOfficeId, OfficeId, VehicleId, Manufacturer, Model)
AS
(
    SELECT
      W.ReturnOfficeId,
      W.OfficeId,
      W.Id,
      W.Manufacturer,
      W.Model
    FROM
      (SELECT
         DENSE_RANK()
         OVER ( PARTITION BY V.Id
           ORDER BY O.CollectionDate DESC ) AS [RANK],
         O.ReturnOfficeId,
         V.OfficeId,
         V.Id,
         M.Manufacturer,
         M.Model
       FROM Models AS M
         JOIN Vehicles AS V
           ON M.Id = V.ModelId
         LEFT JOIN Orders AS O
           ON O.VehicleId = V.Id) AS W
    WHERE W.RANK = 1
)

SELECT
  CONCAT(C.Manufacturer, ' - ', C.Model) AS [Vehicle],
  CASE
  WHEN (SELECT COUNT(*)
        FROM Orders
        WHERE VehicleId = C.VehicleId) = 0 OR C.OfficeId = C.ReturnOfficeId
    THEN 'home'
  WHEN C.ReturnOfficeId IS NULL
    THEN 'on a rent'
  WHEN C.OfficeId <> C.ReturnOfficeId
    THEN (SELECT CONCAT([To].Name, ' - ', [Of].Name)
          FROM Offices AS [Of]
            JOIN Towns AS [To]
              ON [To].Id = [Of].TownId
          WHERE C.ReturnOfficeId = [Of].Id)
  END                                    AS [Location]
FROM CTE_C AS C
ORDER BY Vehicle, C.VehicleId