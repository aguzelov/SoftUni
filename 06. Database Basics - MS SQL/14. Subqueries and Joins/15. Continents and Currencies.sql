SELECT OrderedCurrencies.ContinentCode,
	   OrderedCurrencies.CurrencyCode,
	   OrderedCurrencies.CurrencyUsage
  FROM Continents AS c
  JOIN (
	   SELECT ContinentCode AS [ContinentCode],
	   COUNT(CurrencyCode) AS [CurrencyUsage],
	   CurrencyCode as [CurrencyCode],
	   DENSE_RANK() OVER (PARTITION BY ContinentCode
	                      ORDER BY COUNT(CurrencyCode) DESC
						  ) AS [Rank]
	   FROM Countries
	   GROUP BY ContinentCode, CurrencyCode
	   HAVING COUNT(CurrencyCode) > 1
	   )
	   AS OrderedCurrencies
    ON c.ContinentCode = OrderedCurrencies.ContinentCode
 WHERE OrderedCurrencies.Rank = 1