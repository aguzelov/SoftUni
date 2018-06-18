CREATE PROCEDURE usp_SubmitReview(@customerId    INT,
                                  @reviewContent VARCHAR(255),
                                  @reviewGrade   INT,
                                  @airlineName   VARCHAR(30))
AS
  BEGIN

    DECLARE @AirlineId INT = (
      SELECT AirlineID
      FROM Airlines
      WHERE AirlineName = @airlineName
    )

    IF (@AirlineId IS NULL)
      BEGIN
        RAISERROR ('Airline does not exist.', 16, 1)
        RETURN
      END

    DECLARE @LastId INT = ISNULL((SELECT IDENT_CURRENT('CustomerReviews')), 0) + 1

    INSERT INTO CustomerReviews (ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID) VALUES
      (@LastId, @reviewContent, @reviewGrade, @AirlineId, @customerId)
  END


  SELECT *
  FROM Airlines;