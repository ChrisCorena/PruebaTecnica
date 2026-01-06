using Dapper;
using Microsoft.Data.SqlClient;
using TiendaOnline.Models;

namespace TiendaOnline.Data
{
    public class ProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConexionSQL");
        }

        public async Task<IEnumerable<Producto>> ObtenerProductosAsync()
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryAsync<Producto>(
                "SP_ObtenerProductos",
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task InsertarProductoAsync(Producto producto)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync(
                "SP_InsertarProducto",
                new
                {
                    producto.Nombre,
                    producto.Descripcion,
                    producto.PrecioBase,
                    producto.PrecioDescuento,
                    producto.ImagenUrl
                },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task<Producto?> ObtenerProductoPorIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            return await connection.QueryFirstOrDefaultAsync<Producto>(
                "SELECT * FROM dbo.Productos WHERE Id = @Id",
                new { Id = id }
            );
        }

        public async Task ActualizarProductoAsync(Producto producto)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync(
                "SP_ActualizarProducto",
                new
                {
                    producto.Id,
                    producto.Nombre,
                    producto.Descripcion,
                    producto.PrecioBase,
                    producto.PrecioDescuento,
                    producto.ImagenUrl
                },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }

        public async Task EliminarProductoAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync(
                "SP_EliminarProducto",
                new { Id = id },
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
