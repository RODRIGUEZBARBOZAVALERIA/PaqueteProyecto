
CREATE PROCEDURE [dbo].[Agregar_Usuario]
    @Nombre varchar(50),
    @Correo varchar(100),
    @Hash varchar(max)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Id UNIQUEIDENTIFIER;
    SET @Id = NEWID();

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Usuarios (Id, Nombre, Correo, Hash)
        VALUES (@Id, @Nombre, @Correo, @Hash);

		INSERT INTO PerfilesxUsuarios(IdUsuario, IdPerfil)
        VALUES (@Id, 3);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;