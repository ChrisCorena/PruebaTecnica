CREATE PROCEDURE SP_InsertarProducto
    @Nombre NVARCHAR(150),
    @Descripcion NVARCHAR(500),
    @PrecioBase DECIMAL(18,2),
    @PrecioDescuento DECIMAL(18,2) = NULL,
    @ImagenUrl NVARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Productos (
        Nombre,
        Descripcion,
        PrecioBase,
        PrecioDescuento,
        ImagenUrl
    )
    VALUES (
        @Nombre,
        @Descripcion,
        @PrecioBase,
        @PrecioDescuento,
        @ImagenUrl
    );
END
GO
