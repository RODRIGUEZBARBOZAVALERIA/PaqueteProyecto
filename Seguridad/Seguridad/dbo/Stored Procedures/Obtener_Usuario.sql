
CREATE PROCEDURE [dbo].[Obtener_Usuario]
    @Nombre varchar(50),
    @Correo varchar(100)
AS
BEGIN
    SET NOCOUNT ON;

	SELECT U.Id, U.Nombre, U.Correo
	FROM Usuarios U
	INNER JOIN PerfilesxUsuarios PU ON PU.IdUsuario=U.Id
	WHERE @Nombre = U.Nombre 
	OR @Correo=U.Correo;
END;