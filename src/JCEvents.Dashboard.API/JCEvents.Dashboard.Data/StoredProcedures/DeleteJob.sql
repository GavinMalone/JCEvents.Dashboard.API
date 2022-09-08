CREATE PROCEDURE [dbo].[DeleteJob]
	@jobQuotationNumber nvarchar(max)

AS
	DELETE FROM Jobs
	WHERE Quotation = @jobQuotationNumber

	DELETE FROM AssignedStock
	WHERE JobQuotation = @jobQuotationNumber
