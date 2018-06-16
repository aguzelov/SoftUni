CREATE PROCEDURE usp_SendFeedback(@customerId INT, @productId INT, @rate DECIMAL(10, 2), @description NVARCHAR(255))
AS
  BEGIN
    DECLARE @feedbackCount INT = (
      SELECT count(*)
      FROM Feedbacks
      WHERE CustomerId = @customerId
    )

    IF (@feedbackCount >= 3)
      BEGIN
        RAISERROR ('You are limited to only 3 feedbacks per product!', 16, 1)
      END

    INSERT INTO Feedbacks (Description, Rate, ProductId, CustomerId) VALUES
      (@description, @rate, @productId, @customerId)

  END
