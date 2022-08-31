CREATE PROCEDURE [dbo].[CreateJob]
	@quotation nvarchar(max),
	@title nvarchar(max),
	@contactInformation nvarchar(max),
	@venue nvarchar(max),
	@eventDate datetime,
	@eventType int

AS
	INSERT INTO dbo.Jobs (Quotation, Title, ContactInformation, Venue, EventDate, EventType, IsActive)
	VALUES (@quotation, @title, @contactInformation, @venue, @eventDate, @eventType, 0)
