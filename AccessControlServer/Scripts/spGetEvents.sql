CREATE PROCEDURE spGetEvents
AS
    Set nocount on
	SELECT [Message],  [Details], [Arrivaltime] FROM Event
GO