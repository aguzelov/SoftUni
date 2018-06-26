SELECT
  a.Id                                        AS [AccountId],
  concat(a.FirstName, ' ', a.LastName)        AS [FullName],
  MAX(datediff(DAY, ArrivalDate, ReturnDate)) AS [LongestTrip],
  MIN(datediff(DAY, ArrivalDate, ReturnDate)) AS [ShortestTrip]
FROM Accounts a
  JOIN AccountsTrips at2
    ON a.Id = at2.AccountId
  JOIN Trips t
    ON at2.TripId = t.Id
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY LongestTrip DESC, a.Id