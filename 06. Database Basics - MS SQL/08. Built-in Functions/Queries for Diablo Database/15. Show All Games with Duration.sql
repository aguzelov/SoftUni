SELECT Name AS [Game],
	[Part of the Day] =
	CASE 
		WHEN  DATEPART(hour, Start) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN  DATEPART(hour, Start) BETWEEN 12 AND 17 THEN 'Afternoon' 
		WHEN  DATEPART(hour, Start) BETWEEN 18 AND 24 THEN 'Evening'
	END,
	[Duration] = 
	CASE 
		WHEN Duration BETWEEN 0 AND 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short' 
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END
  FROM Games
 ORDER BY Name ASC, [Duration] ASC, [Part of the Day] ASC