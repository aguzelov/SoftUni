SELECT
  i.Name  AS [Item Name],
  i.Price,
  i.MinLevel,
  gt.Name AS [Forbidden Game Type]
FROM Items AS i
  LEFT JOIN GameTypeForbiddenItems AS gtfi
    ON gtfi.ItemId = i.Id
  LEFT JOIN GameTypes AS gt
    ON gt.Id = gtfi.GameTypeId
ORDER BY [Forbidden Game Type] DESC, [Item Name]