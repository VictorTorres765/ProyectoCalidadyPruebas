using ProyectoEcommerce.Controllers;
using ProyectoEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using ProyectoEcommerce.Models.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering; //Para el renderizado de vistas
using Moq;
using ProyectoEcommerce.Services;
using System.Collections.Generic;


namespace ProyectoEcommerce.Tests.PruebaUnitaria
{
    public class ProductosControllerEditar
    {
        [Fact] //Indica que se ejecutará en XUnit
        public async Task Editar_ProductoExistente_RetornaVistaConProducto()//Metodo para verificar si se edita el un producto existemte
        {
            // Arrange: Configurar el contexto con una base de datos en memoria
            // Crea un contexto de base de datos en memoria para que la prueba no dependa de una base de datos real.
            var options = new DbContextOptionsBuilder<EcommerceContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_Editar")
                .Options;

            using (var context = new EcommerceContext(options))
            {
                // Agregar un producto al contexto
                var producto = new Producto { Id = 1, Nombre = "Producto para Editar", CategoriaId = 1 };
                context.Productos.Add(producto);
                context.SaveChanges();//Guarda el producto en la base de datos en memoria

                // Configurar el servicio de lista para devolver una lista de categorías
                var mockServicioLista = new Mock<IServicioLista>();
                mockServicioLista.Setup(s => s.GetListaCategorias())
                                 .ReturnsAsync(new List<SelectListItem>
                                 {
                                     new SelectListItem { Value = "1", Text = "Categoria 1" }//retorna la lista de categoria con un solo item
                                 });

                var controller = new ProductosController(context, mockServicioLista.Object, null);

                // Act: Llamar al método Editar
                var result = await controller.Editar(1);

                // Assert: Verificar el resultado
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<Producto>(viewResult.Model);
                Assert.Equal(1, model.Id);
                Assert.Equal("Producto para Editar", model.Nombre);
            }
        }
    }
}
