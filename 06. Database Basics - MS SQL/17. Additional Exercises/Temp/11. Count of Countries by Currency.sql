SELECT
  c.CurrencyCode        AS [CurrencyCode],
  c.Description         AS [Currency],
  count(c2.CountryName) AS [NumberOfCountries]
FROM Currencies c
  LEFT JOIN Countries c2
    ON c.CurrencyCode = c2.CurrencyCode
GROUP BY c.CurrencyCode, c.Description
ORDER BY NumberOfCountries DESC, Currency