using ProyectoEcommerce.Controllers;
using ProyectoEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using ProyectoEcommerce.Models.Entidades;

namespace ProyectoEcommerce.Tests.PruebaUnitaria
{
    public class ProductosControllerEliminar
    {
        [Fact]
        public async Task Eliminar_ProductoExistente_EliminaProductoYRedirigeALista()
        {
            // Arrange: Configurar el contexto con una base de datos en memoria
            var options = new DbContextOptionsBuilder<EcommerceContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_Eliminar")
                .Options;

            using (var context = new EcommerceContext(options))
            {
                // Agregar un producto al contexto
                var producto = new Producto { Id = 1, Nombre = "Producto a Eliminar" };
                context.Productos.Add(producto);
                context.SaveChanges();

                var controller = new ProductosController(context, null, null);

                // Act: Llamar al método Eliminar
                var result = await controller.Eliminar(1);

                // Assert: Verificar el resultado
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Lista", redirectToActionResult.ActionName);

                // Verificar que el producto ha sido eliminado
                var productoEliminado = await context.Productos.FindAsync(1);
                Assert.Null(productoEliminado);
            }
        }
    }
}
