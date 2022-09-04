CREATE PROCEDURE [dbo].[UpdateJob]
	@quotation nvarchar(max),
	@title nvarchar(max),
	@contactInformation nvarchar(max),
	@venue nvarchar(max),
	@eventDate datetime,
	@eventType int,
	@what3Words nvarchar(max),
	@rooms nvarchar(max)

AS
	UPDATE Jobs
	SET Quotation = @quotation, Title = @title, ContactInformation = @contactInformation, Venue = @venue, EventDate = @eventDate, EventType = @eventType, What3Words = @what3Words, Rooms = @rooms
	WHERE Quotation = @quotation
