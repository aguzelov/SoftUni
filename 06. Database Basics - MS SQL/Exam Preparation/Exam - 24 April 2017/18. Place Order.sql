CREATE PROCEDURE usp_PlaceOrder(@jobId INT, @serialNumberPart VARCHAR(20), @quantity INT)
AS
  BEGIN
    IF (@quantity <= 0)
      BEGIN
        RAISERROR ('Part quantity must be more than zero!', 16, 1)
        RETURN;
      END

    DECLARE @JobIdSelect INT = (
      SELECT JobId
      FROM Jobs
      WHERE JobId = @jobId
    )

    IF (@JobIdSelect IS NULL)
      BEGIN
        RAISERROR ('Job not found!', 16, 1)
      END

    DECLARE @JobStatus VARCHAR(50) = (
      SELECT Status
      FROM Jobs
      WHERE JobId = @jobId
    )

    IF (@JobStatus = 'Finished')
      BEGIN
        RAISERROR ('This job is not active!', 16, 1)
      END

    DECLARE @PartId INT = (
      SELECT PartId
      FROM Parts
      WHERE SerialNumber = @serialNumberPart
    )

    IF (@PartId IS NULL)
      BEGIN
        RAISERROR ('Part not found!', 16, 1)
      END

    DECLARE @OrderId INT = (
      SELECT o.OrderId
      FROM Orders AS o
        JOIN OrderParts part
          ON o.OrderId = part.OrderId
        JOIN Parts p
          ON part.PartId = p.PartId
      WHERE o.JobId = @jobId AND p.PartId = @PartId AND o.IssueDate IS NULL
    )

    IF (@OrderId IS NULL)
      BEGIN
        INSERT INTO Orders (JobId, IssueDate) VALUES
          (@jobId, NULL)

        INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
          (IDENT_CURRENT('Orders'), @PartId, @quantity)
      END
    ELSE
      BEGIN
        DECLARE @PartExistanceOrder INT = (
          SELECT @@ROWCOUNT
          FROM OrderParts
          WHERE OrderId = @OrderId AND PartId = @PartId
        )

        IF (@PartExistanceOrder IS NULL)
          BEGIN
            INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
              (@OrderId, @PartId, @quantity)
          END
        ELSE
          BEGIN
            UPDATE OrderParts
            SET Quantity += @quantity
            WHERE OrderId = @OrderId AND PartId = @PartId
          END
      END

  END

  DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH
