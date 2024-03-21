SET NOCOUNT ON
GO

IF DB_ID('AccessControl') IS NOT NULL AND ('$(SQLCMDDBNAME)' IN ('', 'master') OR SUBSTRING('$(SQLCMDDBNAME)', 1, 1) = '$')
	USE [AccessControl]
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE Name = 'Severity' And Type in (N'U'))
BEGIN
CREATE TABLE [dbo].Severity(
    [Id] INT IDENTITY(1,1),
	[Name] [NVARCHAR](50) NULL,
	PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
GO

IF 0 = (SELECT COUNT(*) FROM Severity )
BEGIN
	INSERT INTO Severity([Name]) VALUES('Low')
	INSERT INTO Severity([Name]) VALUES('Medium')
	INSERT INTO Severity([Name]) VALUES('High')
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE Name = 'Event' And Type in (N'U'))
BEGIN
CREATE TABLE [dbo].Event(
    [Id] INT IDENTITY(1,1),
	[SeverityId] INT FOREIGN KEY REFERENCES Severity(Id),
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
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(2, 'Failed: Denied Access', 'User 1 is denied access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(3, 'Failed: User Locked out', 'User 1 is locked out to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(2, 'Failed: Denied Access', 'User 1 is denied access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(3, 'Failed: User Locked out', 'User 1 is locked out to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(3, 'Failed: User Locked out', 'User 1 is locked out to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(2, 'Failed: Denied Access', 'User 1 is denied access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(3, 'Failed: User Locked out', 'User 1 is locked out to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(2, 'Failed: Denied Access', 'User 1 is denied access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(3, 'Failed: User Locked out', 'User 1 is locked out to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(3, 'Failed: User Locked out', 'User 1 is locked out to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(2, 'Failed: Denied Access', 'User 1 is denied access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(3, 'Failed: User Locked out', 'User 1 is locked out to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(2, 'Failed: Denied Access', 'User 1 is denied access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(3, 'Failed: User Locked out', 'User 1 is locked out to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(3, 'Failed: User Locked out', 'User 1 is locked out to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
	INSERT INTO [Event](SeverityId, [Message], [Details]) VALUES(1, 'Success : Granted Access', 'User 1 is granted access to door 1.')
END
GO