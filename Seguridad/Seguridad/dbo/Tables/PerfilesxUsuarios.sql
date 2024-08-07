CREATE TABLE [dbo].[PerfilesxUsuarios] (
    [IdUsuario] UNIQUEIDENTIFIER NOT NULL,
    [IdPerfil]  INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    CONSTRAINT [FK_PerfilesxUsuarios_ToPerfiles] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[Perfiles] ([Id]),
    CONSTRAINT [FK_PerfilesxUsuarios_ToUsuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

