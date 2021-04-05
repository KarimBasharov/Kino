﻿CREATE TABLE [dbo].[Movie] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [name]            VARCHAR (70) NULL,
    [duration]        TIME (7)     NULL,
    [age] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);