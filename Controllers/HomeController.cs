using EmpresaMUDDUA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Supabase; // Asegúrate de tener esta referencia

namespace EmpresaMUDDUA.Controllers
{
    public class HomeController : Controller
    {
        private readonly Supabase.Client _supabaseClient;

        public HomeController(Supabase.Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        public IActionResult Index() => View();
        public IActionResult Nosotros() => View();
        public IActionResult Servicios() => View();

        public IActionResult Equipo()
        {
            var equipo = new List<IntegranteViewModel>
            {
                new IntegranteViewModel { Nombre = "Diego Cornejo", Rol = "Líder de Proyecto", Descripcion = "Coordina al equipo y garantiza que cada entrega cumpla los estándares.", GitHub = "https://github.com/Gary750/Ring_salud", ColorClase = "icon-grow", Foto = "/img/equipo/diego.jpeg" },
                new IntegranteViewModel { Nombre = "Denisse Monroy", Rol = "Analista de Sistemas y Tester", Descripcion = "Levanta requerimientos y traduce necesidades del cliente en soluciones.", GitHub = "https://github.com/Gary750/Ring_salud", ColorClase = "icon-dev", Foto = "/img/equipo/denisse.jpeg" },
                new IntegranteViewModel { Nombre = "Melanie Martinez", Rol = "Diseñadora UI/UX y Tester", Descripcion = "Crea prototipos y flujos de usuario centrados en la usabilidad.", GitHub = "https://github.com/Gary750/Ring_salud", ColorClase = "icon-util", Foto = "/img/equipo/melanie.jpeg"},
                new IntegranteViewModel { Nombre = "Uriel Cruz", Rol = "Adaministrador de BD", Descripcion = "Diseña y optimiza bases de datos para garantizar rendimiento y seguridad.", GitHub = "https://github.com/Gary750/Ring_salud", ColorClase = "icon-design", Foto = "/img/equipo/uriel.jpeg" },
                new IntegranteViewModel { Nombre = "Angel Martinez", Rol = "Desarrollador de Sistemas", Descripcion = "Crea soluciones móviles nativas e híbridas de alto rendimiento para iOS y Android.", GitHub = "https://github.com/Gary750/Ring_salud", ColorClase = "icon-design", Foto = "/img/equipo/adrian.jpeg" },
                new IntegranteViewModel { Nombre = "Usiel Sarabia", Rol = "Desarrollador en Sistemas", Descripcion = "Diseña y construye interfaces de programación robustas que permiten la comunicación eficiente entre diversos sistemas y plataformas.", GitHub = "https://github.com/Gary750/Ring_salud", ColorClase = "icon-dev", Foto = "/img/equipo/usiel.jpeg" },
            };
            return View(equipo);
        }

        public IActionResult Contacto() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnviarContacto(ContactoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Contacto", model);
            }

            try
            {
                var nuevoContacto = new Contacto
                {
                    Nombre = model.Nombre,
                    Email = model.Email,
                    Empresa = model.Empresa,
                    Asunto = model.Asunto,
                    Mensaje = model.Mensaje
                };

                // Intentamos insertar en Supabase
                await _supabaseClient.From<Contacto>().Insert(nuevoContacto);

                TempData["Exito"] = "¡Mensaje enviado con éxito! Los datos ya están en Supabase.";
                return RedirectToAction("Contacto");
            }
            catch (Exception ex)
            {
                // Si falla, te mostrará el error real (ej. "401 Unauthorized" si la llave está mal)
                TempData["Error"] = "Error técnico: " + ex.Message;
                return View("Contacto", model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}