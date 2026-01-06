CREATE PROCEDURE SP_ActualizarProducto
    @Id INT,
    @Nombre NVARCHAR(150),
    @Descripcion NVARCHAR(500),
    @PrecioBase DECIMAL(18,2),
    @PrecioDescuento DECIMAL(18,2) = NULL,
    @ImagenUrl NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.Productos
    SET
        Nombre = @Nombre,
        Descripcion = @Descripcion,
        PrecioBase = @PrecioBase,
        PrecioDescuento = @PrecioDescuento,
        ImagenUrl = @ImagenUrl
    WHERE Id = @Id;
END
GO
