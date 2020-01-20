CREATE TABLE [dbo].[Pets] (
    [PetName] NCHAR (128) NULL,
    [Type]    NCHAR (128) NULL,
    [OwnerId] INT         NOT NULL,
    [PetId]   INT         IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Pets] PRIMARY KEY CLUSTERED ([PetId] ASC),
    FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[Owners] ([OwnerId])
);



