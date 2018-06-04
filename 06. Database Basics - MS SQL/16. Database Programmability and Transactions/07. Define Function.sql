CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
  RETURNS BIT
AS
  BEGIN
    DECLARE @isComprised BIT = 0;
    DECLARE @currentIndex INT = 1;
    DECLARE @currentChar CHAR;

    WHILE (@currentIndex <= LEN(@word))
      BEGIN
        SET @currentChar = substring(@word, @currentIndex, 1);
        IF (charindex(@currentChar, @setOfLetters) = 0)
          BEGIN
            RETURN @isComprised;
          END
        SET @currentIndex+= 1;
      END

    RETURN @isComprised + 1;
  END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')