CREATE TABLE [dbo].[Usuarios] (
    [Id]     UNIQUEIDENTIFIER NOT NULL,
    [Nombre] VARCHAR (50)     NULL,
    [Correo] VARCHAR (100)    NOT NULL,
    [Hash]   VARCHAR (MAX)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

