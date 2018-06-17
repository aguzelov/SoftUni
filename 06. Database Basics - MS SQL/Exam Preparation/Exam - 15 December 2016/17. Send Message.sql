CREATE PROCEDURE udp_SendMessage(@userId INT, @chatId INT, @content VARCHAR(200))
AS
  BEGIN
    IF (EXISTS(
        SELECT *
        FROM UsersChats
        WHERE UserId = @userId AND ChatId = @chatId
    ))
      BEGIN
        INSERT INTO Messages (Content, SentOn, ChatId, UserId) VALUES
          (@content, GETDATE(), @chatId, @userId)
      END
    ELSE
      BEGIN
        RAISERROR ('There is no chat with that user!', 16, 1)
      END
  END


