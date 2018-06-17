CREATE FUNCTION udf_CheckForVehicle(@townName NVARCHAR(50), @seatsNumber INT)
  RETURNS NVARCHAR(MAX)
AS
  BEGIN
    DECLARE @result NVARCHAR(MAX) = (SELECT TOP 1 o.Name + ' - ' + m2.Model
                                     FROM Towns AS t
                                       JOIN Offices o
                                         ON t.Id = o.TownId
                                       JOIN Vehicles v
                                         ON o.Id = v.OfficeId
                                       JOIN Models m2
                                         ON v.ModelId = m2.Id
                                     WHERE t.Name = @townName AND m2.Seats = @seatsNumber
                                     GROUP BY o.Name, m2.Model
                                     ORDER BY o.Name ASC)

    IF (@result IS NULL)
      BEGIN
        RETURN 'NO SUCH VEHICLE FOUND'
      END

    RETURN @result
  END
