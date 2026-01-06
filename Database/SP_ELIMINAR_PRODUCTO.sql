CREATE PROCEDURE SP_EliminarProducto
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.Productos
    WHERE Id = @Id;
END
GO
