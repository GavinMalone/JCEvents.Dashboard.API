CREATE PROCEDURE [dbo].[FindJob]
	@quotation nvarchar(MAX)
	
AS
	SELECT * FROM Jobs
	WHERE Quotation = @quotation
