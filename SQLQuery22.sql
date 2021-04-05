CREATE TABLE [dbo].[Saalid]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Saalinimetus] VARCHAR(50) NULL, 
    [Read] INT NULL, 
    [Kohad] INT NULL
)