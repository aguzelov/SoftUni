SELECT TOP 5 e.EmployeeID,
	       e.JobTitle,
	       a.AddressID,
	       a.AddressText 
      FROM Employees AS e
INNER JOIN Addresses AS a ON a.AddressID = e.AddressID
  ORDER BY a.AddressID ASC
