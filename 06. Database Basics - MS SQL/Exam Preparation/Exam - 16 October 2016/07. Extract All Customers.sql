SELECT CustomerID,
  concat(FirstName, ' ', LastName) AS [FullName],
  Gender
FROM Customers
ORDER BY FullName, CustomerID