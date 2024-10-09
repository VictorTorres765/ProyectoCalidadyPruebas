using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoEcommerce.Models;
using ProyectoEcommerce.Models.Entidades;

namespace ProyectoEcommerce.Controllers
{
    [Authorize(Roles = "Administrador")]

    public class CategoriasController : Controller
    {

        private readonly EcommerceContext _context;

        public CategoriasController(EcommerceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Lista()
        {
            return View(await _context.Categorias.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            // Validar si el modelo cumple con las reglas definidas (como el campo Nombre que solo permite letras)
            if (ModelState.IsValid)
            {
                try
                {
                    // Guardar la categoría si todas las validaciones pasaron
                    _context.Add(categoria);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Categoría creada exitosamente!!!";
                    return RedirectToAction("Lista");
                }
                catch
                {
                    // Manejo de errores si ocurre una excepción al guardar
                    ModelState.AddModelError(string.Empty, "La categoría es duplicada, ingresa una correcta");
                }
            }
            else
            {
                // Enviar un mensaje de alerta si el modelo no es válido
                ModelState.AddModelError(string.Empty, "Por favor, corrija los errores y complete todos los campos requeridos.");
            }

            // Si el modelo no es válido, devolver la vista con los datos del formulario para correcciones
            return View(categoria);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Categoria actualizada exitosamente!!!";
                    return RedirectToAction("Lista");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(ex.Message, "Ocurrio un error al actualizar");
                }
            }
            return View(categoria);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            try
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Categoria eliminada exitosamente!!!";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }

            return RedirectToAction(nameof(Lista));
        }
    }
}
