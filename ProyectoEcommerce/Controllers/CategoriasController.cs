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
            var categorias = await _context.Categorias.ToListAsync();
            return View(categorias);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                // Devolver la vista con un mensaje de error si el modelo no es válido
                ModelState.AddModelError(string.Empty, "Por favor, corrija los errores y complete todos los campos requeridos.");
                return View(categoria);
            }

            try
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Categoría creada exitosamente!!!";
                return RedirectToAction("Lista");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "La categoría es duplicada, ingresa una correcta.");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error inesperado. Intenta nuevamente.");
            }

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
                return BadRequest("El ID proporcionado no coincide con el objeto.");
            }

            if (!ModelState.IsValid)
            {
                // Si el modelo no es válido, devolvemos la vista con errores
                ModelState.AddModelError(string.Empty, "Por favor, corrija los errores y complete todos los campos requeridos.");
                return View(categoria);
            }

            try
            {
                _context.Update(categoria);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Categoría actualizada exitosamente!!!";
                return RedirectToAction("Lista");
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "El registro fue modificado por otro usuario. Intenta nuevamente.");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error inesperado. Intenta nuevamente.");
            }

            return View(categoria);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Categorias == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            try
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Categoría eliminada exitosamente!!!";
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "No se pudo eliminar el registro porque está siendo utilizado en otra parte del sistema.");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error inesperado. Intenta nuevamente.");
            }

            return RedirectToAction(nameof(Lista));
        }
    }
}
