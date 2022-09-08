CREATE PROCEDURE [dbo].[RemoveAssignedStockItem]
	@stockItemId int

AS
	DELETE FROM AssignedStock WHERE Id = @stockItemId
