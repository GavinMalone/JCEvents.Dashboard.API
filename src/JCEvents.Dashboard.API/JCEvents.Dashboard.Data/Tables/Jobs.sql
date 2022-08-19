CREATE TABLE [dbo].[Jobs]
(
	[Quotation] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(MAX) NULL, 
    [ContactInformation] NVARCHAR(MAX) NULL, 
    [Venue] NVARCHAR(MAX) NULL, 
    [EventDate] DATETIME NULL, 
    [EventType] NVARCHAR(50) NULL, 
    [IsActive] BIT NULL DEFAULT 0
)
