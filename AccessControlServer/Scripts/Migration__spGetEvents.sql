
IF DB_ID('AccessControl') IS NOT NULL AND ('$(SQLCMDDBNAME)' IN ('', 'master') OR SUBSTRING('$(SQLCMDDBNAME)', 1, 1) = '$')
	USE [AccessControl]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE Name = 'spGetEvents' And Type in (N'P'))
BEGIN
	DROP PROCEDURE spGetEvents
END
GO 

CREATE PROCEDURE spGetEvents
AS
    SET NOCOUNT ON
	SELECT et.[Name] EventType, [Message],  [Details], [Arrivaltime] FROM Event e INNER JOIN EventType et ON e.EventTypeId = et.Id
GO