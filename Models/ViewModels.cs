using System.ComponentModel.DataAnnotations;

namespace EmpresaMUDDUA.Models
{
    // ── Modelo para cada integrante del equipo ──────────────────
    public class IntegranteViewModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string GitHub { get; set; } = "#";
        public string LinkedIn { get; set; } = "#";
        public string ColorClase { get; set; } = "icon-design";
        public string? Foto { get; set; }
    }

    // ── Modelo del formulario de contacto ───────────────────────
    public class ContactoViewModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Ingresa un correo válido")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Empresa (opcional)")]
        public string? Empresa { get; set; }

        [Required(ErrorMessage = "El asunto es requerido")]
        [Display(Name = "Asunto")]
        public string Asunto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El mensaje es requerido")]
        [MinLength(10, ErrorMessage = "Mínimo 10 caracteres")]
        [Display(Name = "Mensaje")]
        public string Mensaje { get; set; } = string.Empty;
    }

}