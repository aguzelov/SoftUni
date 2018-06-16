CREATE VIEW v_UserWithCountries AS
  SELECT
    concat(c.FirstName, ' ', c.LastName) AS [CustomerName],
    c.Age                                AS [Age],
    c.Gender                             AS [Gender],
    c2.Name                              AS [CountryName]
  FROM Customers c
    JOIN Countries c2
      ON c.CountryId = c2.Id