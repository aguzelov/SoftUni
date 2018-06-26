/*
Create a trigger, which fires when a trip is deleted.
Instead of deleting a trip, set its cancel date to the current date and IGNORE trips,
which have already been canceled.
 */

CREATE TRIGGER TR_Trips
  ON Trips
  INSTEAD OF DELETE
AS
  BEGIN

    UPDATE Trips
    SET CancelDate = GETDATE()
    WHERE Id IN (SELECT Id
                 FROM deleted)
          AND CancelDate IS NULL
  END