CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
  RETURNS NVARCHAR(MAX)
AS
  BEGIN

    DECLARE @roomId INT = (
      SELECT r.Id
      FROM Hotels h
        JOIN Rooms r
          ON h.Id = r.HotelId
      WHERE h.Id = @HotelId AND r.Beds >= @People
      GROUP BY r.Id, r.Price
      HAVING r.Price = (
        SELECT max(r.Price)
        FROM Hotels h
          JOIN Rooms r
            ON h.Id = r.HotelId
        WHERE h.Id = @HotelId AND r.Beds >= @People
      )
    )

    IF (@roomId IS NULL)
      BEGIN
        RETURN 'No rooms available'
      END

    IF exists(SELECT *
              FROM Trips
              WHERE RoomId = @roomId AND @Date BETWEEN ArrivalDate AND ReturnDate)
      BEGIN
        RETURN 'No rooms available'
      END

    DECLARE @roomPrice DECIMAL(15, 2) = (
      SELECT Price
      FROM Rooms
      WHERE Id = @roomId
    )

    DECLARE @roomType NVARCHAR(20) = (
      SELECT Type
      FROM Rooms
      WHERE Id = @roomId
    )

    DECLARE @beds INT = (
      SELECT Beds
      FROM Rooms
      WHERE Id = @roomId
    )

    DECLARE @hotelBaseRate DECIMAL(15, 2) = (
      SELECT BaseRate
      FROM Hotels
      WHERE Id = @HotelId
    )

    DECLARE @totalPrice DECIMAL(15, 2) = (@hotelBaseRate + @roomPrice) * @People

    RETURN concat('Room ', @roomId, ': ', @roomType, ' (', @beds, ' beds) - $', @totalPrice)

  END
