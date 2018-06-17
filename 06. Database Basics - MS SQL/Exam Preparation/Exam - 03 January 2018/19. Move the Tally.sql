CREATE TRIGGER TR_AddMileage
  ON Orders
  AFTER UPDATE
AS
  BEGIN
    DECLARE @newTotalMileage INT = (
      SELECT TotalMileage
      FROM inserted
    )
    DECLARE @vehicleId INT = (
      SELECT VehicleId
      FROM inserted
    )

    DECLARE @oldTotalMileage INT = (
      SELECT TotalMileage
      FROM deleted
    )

    IF (@oldTotalMileage IS NULL AND @vehicleId IS NOT NULL)
      BEGIN
        UPDATE Vehicles
        SET Mileage += @newTotalMileage
        WHERE Id = @vehicleId
      END
  END