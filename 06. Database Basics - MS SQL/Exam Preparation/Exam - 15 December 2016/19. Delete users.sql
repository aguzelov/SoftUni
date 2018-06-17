CREATE TRIGGER TR_DeleteUser
  ON Users
  INSTEAD OF DELETE
AS
  BEGIN
    DECLARE @UserId INT = (
      SELECT Id
      FROM deleted
    )

    DELETE FROM UsersChats
    WHERE UserId = @UserId

    DELETE FROM Messages
    WHERE UserId = @UserId

    DELETE FROM Users
    WHERE Id = @UserId

  END