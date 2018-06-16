SELECT
  Name,
  Description,
  OriginCountryId
FROM Ingredients
WHERE OriginCountryId IN (1, 10, 20)
ORDER BY Id