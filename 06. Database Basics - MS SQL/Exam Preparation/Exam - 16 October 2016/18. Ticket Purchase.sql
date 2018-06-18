CREATE PROCEDURE usp_PurchaseTicket(@CustomerID  INT,
                                    @FlightID    INT,
                                    @TicketPrice DECIMAL(8, 2),
                                    @Class       VARCHAR(6),
                                    @Seat        VARCHAR(5))
AS
  BEGIN
    DECLARE @CustomerBalance DECIMAL(10, 2) = (
      SELECT Balance
      FROM CustomerBankAccounts
      WHERE CustomerID = @CustomerID
    )

    IF (@TicketPrice > isnull(@CustomerBalance, 0))
      BEGIN
        RAISERROR ('Insufficient bank account balance for ticket purchase.', 16, 1)
        RETURN
      END

    DECLARE @TicketLastID INT = isnull((SELECT MAX(TicketID)
                                        FROM Tickets), 0) + 1

    INSERT INTO Tickets (TicketID, Price, Class, Seat, CustomerID, FlightID) VALUES
      (@TicketLastID, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

    UPDATE CustomerBankAccounts
    SET Balance -= @TicketPrice
    WHERE CustomerID = @CustomerID
  END