CREATE FUNCTION udf_GetRating(@productName NVARCHAR(25))
  RETURNS NVARCHAR(10)
AS
  BEGIN

    DECLARE @productRate DECIMAL(10, 2) = (
      SELECT avg(f.Rate)
      FROM Products p
        JOIN Feedbacks f
          ON p.Id = f.ProductId
      WHERE p.Name = @productName
    )


    IF (@productRate < 5)
      BEGIN
        RETURN 'Bad'
      END
    ELSE IF (@productRate BETWEEN 5 AND 8)
      BEGIN
        RETURN 'Average'
      END
    ELSE IF (@productRate > 8)
      BEGIN
        RETURN 'Good'
      END

    RETURN 'No rating'

  END
