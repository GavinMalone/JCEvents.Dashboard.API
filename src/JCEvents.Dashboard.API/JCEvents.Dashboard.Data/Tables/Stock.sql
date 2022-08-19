CREATE TABLE [dbo].[Stock]
(
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Quantity] INT NULL, 
    [StatusId] INT NULL, 
    [ServiceDate] DATETIME NULL, 
    [GroupId] INT NULL, 
    [Weight] DECIMAL NULL, 
    [IsAssigned] BIT NULL DEFAULT 0
)