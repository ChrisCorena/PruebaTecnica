CREATE PROCEDURE SP_ObtenerProductos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Nombre,
        Descripcion,
        PrecioBase,
        PrecioDescuento,
        ImagenUrl,
        FechaCreacion
    FROM Productos
    ORDER BY FechaCreacion DESC;
END
GO

EXEC SP_ObtenerProductos;
