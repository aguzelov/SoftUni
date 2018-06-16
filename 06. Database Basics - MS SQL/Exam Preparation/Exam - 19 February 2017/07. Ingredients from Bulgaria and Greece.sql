SELECT TOP (15)
  i.Name,
  i.Description,
  c.Name
FROM Ingredients i
  JOIN Countries c
    ON i.OriginCountryId = c.Id
WHERE c.Name IN ('Bulgaria', 'Greece')
ORDER BY i.Name, c.Name