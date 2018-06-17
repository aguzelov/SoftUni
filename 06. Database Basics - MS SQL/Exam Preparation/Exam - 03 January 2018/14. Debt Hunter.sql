WITH cte_Ranked (ClientName, Bill, Email, TownName, Rank, ClientId) AS
(
    SELECT
      concat(c.FirstName, ' ', c.LastName) AS [Category Name],
      o.Bill,
      c.Email,
      t.Name,
      DENSE_RANK()
      OVER ( PARTITION BY t.Id
        ORDER BY o.Bill DESC )             AS Rank,
      c.Id
    FROM Towns t
      JOIN Orders o
        ON t.Id = o.TownId
      JOIN Clients c
        ON o.ClientId = c.Id
    WHERE datediff(DAY, c.CardValidity, o.CollectionDate) > 0 AND o.Bill IS NOT NULL
    GROUP BY t.Id, o.Bill, concat(c.FirstName, ' ', c.LastName), t.Name, c.Email, c.Id
)

SELECT
  cte.ClientName AS [Category Name],
  cte.Email      AS [Email],
  cte.Bill       AS [Bill],
  cte.TownName   AS [Town]
FROM cte_ranked AS cte
WHERE cte.Rank = 1 OR cte.Rank = 2
ORDER BY cte.TownName, cte.Bill, cte.ClientId