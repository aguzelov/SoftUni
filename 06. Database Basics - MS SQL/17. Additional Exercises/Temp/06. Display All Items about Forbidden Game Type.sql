SELECT
  i.Name  AS [Item],
  i.Price,
  i.MinLevel,
  gt.Name AS [Forbidden Game Type]
FROM Items i
  LEFT JOIN GameTypeForbiddenItems gtf
    ON i.Id = gtf.ItemId
  LEFT JOIN GameTypes gt
    ON gtf.GameTypeId = gt.Id
ORDER BY [Forbidden Game Type] DESC, Item
