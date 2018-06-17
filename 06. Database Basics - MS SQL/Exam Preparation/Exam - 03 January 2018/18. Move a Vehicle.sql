CREATE PROCEDURE usp_MoveVehicle(@vehicleId INT, @officeId INT)
AS
  BEGIN
    BEGIN TRANSACTION
    DECLARE @officePlaces INT = (
      SELECT ParkingPlaces
      FROM Offices
      WHERE Id = @officeId
    )

    DECLARE @currentPlaces INT = (
      SELECT count(v.OfficeId)
      FROM Vehicles v
        JOIN Offices o
          ON v.OfficeId = o.Id
      WHERE o.Id = @officeId
      GROUP BY o.Name
    )

    IF (@officePlaces IS NULL OR @currentPlaces IS NULL OR @currentPlaces >= @officePlaces)
      BEGIN
        ROLLBACK;
        RAISERROR ('Not enough room in this office!', 16, 1);
      END

    UPDATE Vehicles
    SET OfficeId = @officeId
    WHERE Id = @vehicleId

    COMMIT;
  END


