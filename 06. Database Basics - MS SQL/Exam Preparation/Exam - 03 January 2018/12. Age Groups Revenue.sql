SELECT
  CASE
  WHEN c.BirthDate BETWEEN '1970' AND '1980'
    THEN '70''s'
  WHEN c.BirthDate BETWEEN '1980' AND '1990'
    THEN '80''s'
  WHEN c.BirthDate BETWEEN '1990' AND '2000'
    THEN '90''s'
  WHEN c.BirthDate NOT BETWEEN '1970' AND '2000'
    THEN 'Others'
  END                 AS AgeGroup,
  SUM(o.Bill)         AS Revenue,
  AVG(o.TotalMileage) AS AverageMileage
FROM Clients AS c
  LEFT JOIN Orders AS o
    ON c.Id = o.ClientId
  JOIN Vehicles AS v
    ON o.VehicleId = v.Id
GROUP BY (CASE
          WHEN c.BirthDate BETWEEN '1970' AND '1980'
            THEN '70''s'
          WHEN c.BirthDate BETWEEN '1980' AND '1990'
            THEN '80''s'
          WHEN c.BirthDate BETWEEN '1990' AND '2000'
            THEN '90''s'
          WHEN c.BirthDate NOT BETWEEN '1970' AND '2000'
            THEN 'Others'
          END)
ORDER BY AgeGroup ASC