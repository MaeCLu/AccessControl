SET NOCOUNT ON
GO

IF DB_ID('AccessControl') IS NOT NULL AND ('$(SQLCMDDBNAME)' IN ('', 'master') OR SUBSTRING('$(SQLCMDDBNAME)', 1, 1) = '$')
	USE [AccessControl]
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE Name = 'EventType' And Type in (N'U'))
BEGIN
CREATE TABLE [dbo].EventType(
    [Id] INT IDENTITY(1,1),
	[Name] [NVARCHAR](50) NULL,
	PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO
IF 0 = (SELECT COUNT(*) FROM EventType )
BEGIN
	INSERT INTO EventType([Name]) VALUES('High')
	INSERT INTO EventType([Name]) VALUES('Medium')
	INSERT INTO EventType([Name]) VALUES('Low')
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE Name = 'Event' And Type in (N'U'))
BEGIN
CREATE TABLE [dbo].Event(
    [Id] INT IDENTITY(1,1),
	[EventTypeId] INT FOREIGN KEY REFERENCES EventType(Id),
	[Message] [NVARCHAR](2048) NULL,
	[Details] [NVARCHAR](MAX) NULL,
	[ArrivalTime] DATETIME NOT NULL DEFAULT GETUTCDATE(),
	PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]	
END
GO

IF 0 = (SELECT COUNT(*) FROM Event )
BEGIN
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Service is down', 'Event service is down')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(2, 'Api failure', 'Get event api failed')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(3, 'Network too slow', 'Processing of requests are taking a while')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Failed service startup', 'Event service failed to startup')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Network is down', 'Local network is not accessible')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(2, 'Request queue is getting large', 'Event service requests are large')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(3, 'Low speed connection', 'Network is slow')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(3, 'Api not getting data', 'Event API is returning no data')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Authentication failed', 'User failure authentication')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Access Denied', 'User 1 is access denied')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Login lockout', 'User 1 login is locked out')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Service is down', 'Event service is down')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(2, 'Api failure', 'Get event api failed')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(3, 'Network too slow', 'Processing of requests are taking a while')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Failed service startup', 'Event service failed to startup')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Network is down', 'Local network is not accessible')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(2, 'Request queue is getting large', 'Event service requests are large')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(3, 'Low speed connection', 'Network is slow')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(3, 'Api not getting data', 'Event API is returning no data')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Authentication failed', 'User failure authentication')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Access Denied', 'User 1 is access denied')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Login lockout', 'User 1 login is locked out')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Service is down', 'Event service is down')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(2, 'Api failure', 'Get event api failed')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(3, 'Network too slow', 'Processing of requests are taking a while')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Failed service startup', 'Event service failed to startup')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Network is down', 'Local network is not accessible')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(2, 'Request queue is getting large', 'Event service requests are large')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(3, 'Low speed connection', 'Network is slow')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(3, 'Api not getting data', 'Event API is returning no data')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Authentication failed', 'User failure authentication')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Access Denied', 'User 1 is access denied')
	INSERT INTO [Event](EventTypeId, [Message], [Details]) VALUES(1, 'Login lockout', 'User 1 login is locked out')
END
GO