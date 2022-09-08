CREATE PROCEDURE [dbo].[RetrieveStockAssignedToJob]
	@jobQuotation nvarchar(max)

AS
	SELECT [AS].Id, S.Name, [AS].Quantity FROM dbo.AssignedStock [AS]
	INNER JOIN Stock S ON [AS].StockId = S.Id
	WHERE [AS].JobQuotation = @jobQuotation
