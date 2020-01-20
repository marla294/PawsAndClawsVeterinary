CREATE TABLE [dbo].[Appointments] (
    [PetId]             INT         NOT NULL,
    [AppointmentDate]   DATETIME    NULL,
    [AppointmentReason] NCHAR (128) NULL,
    [AppointmentId]     INT         IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([AppointmentId] ASC),
    FOREIGN KEY ([PetId]) REFERENCES [dbo].[Pets] ([PetId])
);

