SELECT
  FirstName,
  Age,
  PhoneNumber
FROM Customers
WHERE (Age >= 21 AND FirstName LIKE '%an%') OR
  (RIGHT(PhoneNumber,2) = '38' and CountryId <> 31)
ORDER BY FirstName, Age DESC