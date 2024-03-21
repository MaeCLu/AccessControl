
IF DB_ID('AccessControl') IS NOT NULL AND ('$(SQLCMDDBNAME)' IN ('', 'master') OR SUBSTRING('$(SQLCMDDBNAME)', 1, 1) = '$')
	USE [AccessControl]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE Name = 'spPostEvents' And Type in (N'P'))
BEGIN
	DROP PROCEDURE spPostEvents
END
GO 

CREATE PROCEDURE dbo.spPostEvents 
       @SeverityId  Integer, 
       @Message     [NVARCHAR](2048) NULL,
       @Details     [NVARCHAR](MAX) NULL
AS 
BEGIN 
     SET NOCOUNT ON 

     INSERT INTO dbo.Event
          (                    
            SeverityId,
            Message,
            Details
          ) 
     VALUES 
          ( 
            @SeverityId,
            @Message,
            @Details
          ) 

END 

GO
