BULK
INSERT CSVTest
FROM 'C:\Users\stanimir\Downloads\ProblemList.csv'
WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO
--Check the content of the table.
SELECT *
FROM CSVTest
GO