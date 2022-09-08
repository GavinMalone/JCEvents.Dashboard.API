CREATE TABLE [dbo].[AssignedStock]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StockId] INT NULL, 
    [JobQuotation] NVARCHAR(MAX) NULL, 
    [Quantity] INT NULL
)
