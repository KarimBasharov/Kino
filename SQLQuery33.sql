CREATE TABLE [dbo].[Session]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Date] DATE NULL, 
    [Time] TIME NULL, 
    [Film] INT NULL,
	CONSTRAINT [FK_Session_ToMovie] FOREIGN KEY ([Film]) REFERENCES [dbo].[Movie]([Id])
)