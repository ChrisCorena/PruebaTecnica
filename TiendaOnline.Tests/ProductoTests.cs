using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TiendaOnline.Models;
using Xunit;

namespace TiendaOnline.Tests
{
    public class ProductoTests
    {
        [Fact]
        public void Producto_PrecioBase_MenorOIgualCero_NoEsValido()
        {
            // Arrange
            var producto = new Producto
            {
                Nombre = "Producto prueba",
                Descripcion = "Descripcion",
                PrecioBase = 0
            };

            var context = new ValidationContext(producto);
            var results = new List<ValidationResult>();

            // Act
            var esValido = Validator.TryValidateObject(
                producto,
                context,
                results,
                true
            );

            // Assert
            Assert.False(esValido);
        }

        [Fact]
        public void Producto_PrecioBase_MayorCero_EsValido()
        {
            // Arrange
            var producto = new Producto
            {
                Nombre = "Producto prueba",
                Descripcion = "Descripcion",
                PrecioBase = 100
            };

            var context = new ValidationContext(producto);
            var results = new List<ValidationResult>();

            // Act
            var esValido = Validator.TryValidateObject(
                producto,
                context,
                results,
                true
            );

            // Assert
            Assert.True(esValido);
        }

        [Fact]
        public void Producto_PrecioDescuento_Negativo_NoEsValido()
        {
            var producto = new Producto
            {
                Nombre = "Producto prueba",
                Descripcion = "Descripcion",
                PrecioBase = 100,
                PrecioDescuento = -10
            };

            var context = new ValidationContext(producto);
            var results = new List<ValidationResult>();

            var esValido = Validator.TryValidateObject(
                producto,
                context,
                results,
                true
            );

            Assert.False(esValido);
        }

        [Fact]
        public void Producto_SinPrecioDescuento_EsValido()
        {
            var producto = new Producto
            {
                Nombre = "Producto prueba",
                Descripcion = "Descripcion",
                PrecioBase = 100,
                PrecioDescuento = null
            };

            var context = new ValidationContext(producto);
            var results = new List<ValidationResult>();

            var esValido = Validator.TryValidateObject(
                producto,
                context,
                results,
                true
            );

            Assert.True(esValido);
        }

    }
}
