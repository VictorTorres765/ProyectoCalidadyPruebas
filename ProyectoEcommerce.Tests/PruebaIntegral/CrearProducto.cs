using Moq;
using ProyectoEcommerce.Controllers;
using ProyectoEcommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using ProyectoEcommerce.Models.Entidades;

namespace ProyectoEcommerce.Tests.PruebaIntegral
{
    public class CrearProducto
    {
        [Fact]
        public async Task CrearProducto_DirectoEnBaseDatos()
        {
            // Arrange: Configurar el contexto con una base de datos en memoria
            var options = new DbContextOptionsBuilder<EcommerceContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_CrearProductoDirecto")
                .Options;

            using (var context = new EcommerceContext(options))
            {
                var controller = new ProductosController(context, null, null);

                // Crear un producto válido (sin imagen ni lista de categorías)
                var producto = new Producto
                {
                    Nombre = "Producto Simple",
                    CategoriaId = 1,
                    Precio = 15.0m,
                    Descripcion = "Descripción del producto",
                    Inventario = 10
                };

                // Act: Llamar al método Crear para agregar el producto
                context.Productos.Add(producto);
                await context.SaveChangesAsync();

                // Assert: Verificar que el producto fue agregado a la base de datos
                var productoGuardado = await context.Productos.FindAsync(producto.Id);
                Assert.NotNull(productoGuardado);
                Assert.Equal("Producto Simple", productoGuardado.Nombre);
            }
        }
    }
}
