using ProyectoEcommerce.Controllers;
using ProyectoEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using ProyectoEcommerce.Models.Entidades;

public class ProductosControllerTests
{
    [Fact]
    public async Task Lista_RetornaVistaConListaDeProductos()
    {
        // Arrange: Configurar el contexto con una base de datos en memoria
        var options = new DbContextOptionsBuilder<EcommerceContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new EcommerceContext(options))
        {
            // Agregar datos de prueba para las categorías
            var categoria = new Categoria { Id = 1, Nombre = "Categoria 1" };
            context.Categorias.Add(categoria);
            context.SaveChanges();

            // Agregar productos de prueba con la categoría asociada
            context.Productos.Add(new Producto { Id = 1, Nombre = "Producto 1", Categoria = categoria });
            context.Productos.Add(new Producto { Id = 2, Nombre = "Producto 2", Categoria = categoria });
            context.SaveChanges();

            // Crear el controlador con el mismo contexto
            var controller = new ProductosController(context, null, null);

            // Act: Llamar al método Lista del controlador
            var result = await controller.Lista();

            // Assert: Verificar que el resultado es una vista con los productos correctos
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Producto>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }
    }
}
