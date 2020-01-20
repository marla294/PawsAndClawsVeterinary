CREATE TABLE [dbo].[Owners] (
    [First]   NCHAR (128) NULL,
    [Last]    NCHAR (128) NULL,
    [Phone]   NCHAR (16)  NULL,
    [Address] NCHAR (128) NULL,
    [OwnerId] INT         IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED ([OwnerId] ASC)
);

