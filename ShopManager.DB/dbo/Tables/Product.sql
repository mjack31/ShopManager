CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(128) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CreateDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [LastModificationDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
