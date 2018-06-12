CREATE TRIGGER T_CloseReport
  ON Reports
  AFTER UPDATE
AS
  BEGIN
    DECLARE @statusId INT = (SELECT Id
                             FROM Status
                             WHERE Label = 'completed')

    UPDATE Reports
    SET StatusId = @statusId
    WHERE Id IN (
      SELECT Id
      FROM inserted
      WHERE Id IN (
        SELECT Id
        FROM deleted
        WHERE CloseDate IS NULL)
            AND Reports.CloseDate IS NOT NULL
    )
  END
