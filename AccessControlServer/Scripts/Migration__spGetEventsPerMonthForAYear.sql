
IF DB_ID('AccessControl') IS NOT NULL AND ('$(SQLCMDDBNAME)' IN ('', 'master') OR SUBSTRING('$(SQLCMDDBNAME)', 1, 1) = '$')
	USE [AccessControl]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE Name = 'spGetEventsPerMonthForAYear' And Type in (N'P'))
BEGIN
	DROP PROCEDURE spGetEventsPerMonthForAYear
END
GO 

CREATE PROCEDURE spGetEventsPerMonthForAYear
AS
    SET NOCOUNT ON

	SELECT YEAR(e.ArrivalTime) AS year,
       MONTH(e.ArrivalTime) AS month,
	   et.Name AS EventType,
       COUNT(*) AS Total
	FROM   Event e 
	INNER JOIN EventType et ON e.EventTypeId = et.Id
	WHERE  YEAR(e.ArrivalTime) = YEAR(GETDATE())
	GROUP BY
       MONTH(e.ArrivalTime),
	   YEAR(e.ArrivalTime),
	   et.Name
	ORDER BY MONTH(e.ArrivalTime)
GO