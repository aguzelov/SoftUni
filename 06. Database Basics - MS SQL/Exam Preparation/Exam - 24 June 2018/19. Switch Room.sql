CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
  BEGIN
    DECLARE @currentTripHotelId INT = (
      SELECT r.HotelId
      FROM Trips t
        JOIN Rooms r
          ON t.RoomId = r.Id
      WHERE t.Id = @TripId
    )

    DECLARE @targetRoomHotelId INT = (
      SELECT HotelId
      FROM Rooms
      WHERE Id = @TargetRoomId
    )

    IF (@currentTripHotelId <> @targetRoomHotelId)
      BEGIN
        RAISERROR ('Target room is in another hotel!', 16, 1)
        RETURN
      END

    DECLARE @neededBeds INT = (
      SELECT count(AccountId)
      FROM Trips t
        JOIN AccountsTrips at2
          ON t.Id = at2.TripId
      WHERE t.Id = @TripId
    )

    DECLARE @actualBeds INT = (
      SELECT Beds
      FROM Rooms
      WHERE Id = @TargetRoomId
    )


    IF (@neededBeds > @actualBeds)
      BEGIN
        RAISERROR ('Not enough beds in target room!', 16, 2)
        RETURN
      END

    UPDATE Trips
    SET RoomId = @TargetRoomId
    WHERE Id = @TripId

  END

  EXEC usp_SwitchRoom 10, 11
  SELECT RoomId
  FROM Trips
  WHERE Id = 10
