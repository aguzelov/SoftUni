CREATE FUNCTION udf_GetRadians(@degrees FLOAT)
  RETURNS FLOAT
AS
  BEGIN
    DECLARE @result FLOAT = (@degrees * PI()) / 180

    RETURN @result
  END