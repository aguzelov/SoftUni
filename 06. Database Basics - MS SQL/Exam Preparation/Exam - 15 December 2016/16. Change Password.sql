CREATE PROCEDURE udp_ChangePassword(@email VARCHAR(30), @newPassword VARCHAR(20))
AS
  BEGIN
    DECLARE @CredId INT = (
      SELECT Id
      FROM Credentials
      WHERE Email = @email
    )

    IF (@CredId IS NULL)
      BEGIN
        RAISERROR ('The email does''t exist!', 16, 1)
      END

    UPDATE Credentials
    SET Password = @newPassword
    WHERE Email = @email
  END
