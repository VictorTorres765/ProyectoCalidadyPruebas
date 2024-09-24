using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using ProyectoEcommerce.Enums;
using ProyectoEcommerce.Models;
using ProyectoEcommerce.Models.Entidades;
using ProyectoEcommerce.Services;

namespace ProyectoEcommerce.Controllers
{
    public class LoginController : Controller
    {

        private readonly IServicioUsuario _servicioUsuario;
        private readonly IServicioLista _servicioLista;
        private readonly IServicioImagen _servicioImagen;
        private readonly EcommerceContext _context;

        public LoginController(IServicioUsuario servicioUsuario, IServicioLista servicioLista, 
            IServicioImagen servicioImagen, EcommerceContext context)
        {
            _servicioUsuario = servicioUsuario;
            _servicioLista = servicioLista;
            _servicioImagen = servicioImagen;
            _context = context;
        }

        public IActionResult IniciarSesion()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _servicioUsuario.IniciarSesion(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Email o contraseña incorrectos.");
            }
            return View(model);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _servicioUsuario.CerrarSesion();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult NoAutorizado()
        {
            return View();
        }

        public IActionResult Registro()
        {
            UsuarioViewModel model = new()
            {
                Id = Guid.Empty.ToString(),
                TipoUsuario = TipoUsuario.Cliente,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //CODIGO ORIGINAL DE LA FOTO, SI HAY ERROR REGRESARLO A LA NORMALIDAD EN CREAR USUARIO GENERAL
        //public async Task<IActionResult> Registro(UsuarioViewModel model, IFormFile Imagen)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Stream image = Imagen.OpenReadStream();
        //        string urlImagen = await _servicioImagen.SubirImagen(image, Imagen.FileName);

        //        model.URLFoto = urlImagen;

        //        Usuario usuario = await _servicioUsuario.CrearUsuario(model);
        //        if (usuario == null)
        //        {
        //            ModelState.AddModelError(string.Empty, "Este correo ya está siendo usado.");
        //            return View(model);
        //        }
        //        LoginViewModel loginViewModel = new()
        //        {
        //            Password = model.Password,
        //            RememberMe = false,
        //            Username = model.Username
        //        };
        //        var result = await _servicioUsuario.IniciarSesion(loginViewModel);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    return View(model);
        //}

        //CÓDIGO PARA LA IMAGEN MODIFICADO, SI HAY ERROR REGRESARLO A LA NORMALIDAD
        public async Task<IActionResult> Registro(UsuarioViewModel model, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                // Verifica si se subió una imagen
                if (Imagen != null)
                {
                    using (Stream image = Imagen.OpenReadStream())
                    {
                        string urlImagen = await _servicioImagen.SubirImagen(image, Imagen.FileName);
                        model.URLFoto = urlImagen;
                    }
                }
                else
                {
                    // Si no se subió imagen, URLFoto queda sin asignar o con un valor predeterminado
                    model.URLFoto = null;
                }

                // Crea el usuario con los datos proporcionados
                Usuario usuario = await _servicioUsuario.CrearUsuario(model);
                if (usuario == null)
                {
                    ModelState.AddModelError(string.Empty, "Este correo ya está siendo usado.");
                    return View(model);
                }

                // Inicia sesión con el usuario recién creado
                LoginViewModel loginViewModel = new()
                {
                    Password = model.Password,
                    RememberMe = false,
                    Username = model.Username
                };
                var result = await _servicioUsuario.IniciarSesion(loginViewModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // Si algo falla o no es válido, se regresa el modelo para su corrección
            return View(model);
        }
        //HASTA AQUI ES EL NUEVO CÓDIGO

        public async Task<IActionResult> EditarUsuario()
        {
            Usuario usuario = await _servicioUsuario.ObtenerUsuario(User.Identity.Name);
            if (usuario == null)
            {
                return NotFound();
            }
            
            Usuario model = new()
            {
                Nombre = usuario.Nombre,
                PhoneNumber = usuario.PhoneNumber,
                URLFoto = usuario.URLFoto,             
                Id = usuario.Id,                
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //EDITAR USUARIO DENTRO DE LA MISMA CUENTA DEL USUARIO(CLIENTE) CON IMAGEN 
        //ESTE ES EL CODIGO ORIGINAL, REGRESAR SI HAY ERRORES EN LA CORRECIÓN
        //public async Task<IActionResult> EditarUsuario(Usuario model, IFormFile Imagen)
        //{
        //    if (ModelState.IsValid)
        //    {                           
        //        Usuario usuario = await _servicioUsuario.ObtenerUsuario(User.Identity.Name);
        //        usuario.Nombre = model.Nombre;
        //        usuario.PhoneNumber = model.PhoneNumber;

        //        Stream image = Imagen.OpenReadStream();
        //        string urlImagen = await _servicioImagen.SubirImagen(image, Imagen.FileName);
        //        usuario.URLFoto = urlImagen;

        //        await _servicioUsuario.ActualizarUsuario(usuario);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View(model);
        //}
        //HASTA AQUÍ

        //DESDE AQUI EL CONTROLAR LA IMAGEN NO NECESARIA, BORRAR SI DA CONFLICTO NO SE RQUIERE DE LA IMAGEN 
        public async Task<IActionResult> EditarUsuario(Usuario model, IFormFile Imagen)
        {
            if (ModelState.IsValid)
            {
                // Obtiene el usuario actual
                Usuario usuario = await _servicioUsuario.ObtenerUsuario(User.Identity.Name);
                usuario.Nombre = model.Nombre;
                usuario.PhoneNumber = model.PhoneNumber;

                // Verifica si se subió una imagen antes de intentar procesarla
                if (Imagen != null)
                {
                    using (Stream image = Imagen.OpenReadStream())
                    {
                        string urlImagen = await _servicioImagen.SubirImagen(image, Imagen.FileName);
                        usuario.URLFoto = urlImagen;
                    }
                }
                else
                {
                    // Si no se sube una nueva imagen, mantiene la URL de la foto existente
                    usuario.URLFoto = usuario.URLFoto;
                }

                // Actualiza la información del usuario
                await _servicioUsuario.ActualizarUsuario(usuario);
                return RedirectToAction("Index", "Home");
            }

            // Si algo falla, regresa el modelo para su corrección
            return View(model);
        }
        //HASTA AQUÍ

        public IActionResult CambiarPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CambiarPassword(PasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _servicioUsuario.ObtenerUsuario(User.Identity.Name);
                if (usuario != null)
                {
                    var result = await _servicioUsuario.CambiarPassword(usuario, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("EditarUsuario");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario no encontrado.");
                }
            }
            return View(model);
        }
    }
}
