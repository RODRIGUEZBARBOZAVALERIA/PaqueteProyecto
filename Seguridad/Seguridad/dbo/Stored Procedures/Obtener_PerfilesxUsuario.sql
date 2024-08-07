
CREATE PROCEDURE Obtener_PerfilesxUsuario
    @Id uniqueidentifier
AS
BEGIN
    SET NOCOUNT ON;

	SELECT P.Id
	FROM PerfilesxUsuarios PU
	INNER JOIN Perfiles P ON P.Id= PU.IdPerfil
	WHERE @Id = PU.IdUsuario;
END;