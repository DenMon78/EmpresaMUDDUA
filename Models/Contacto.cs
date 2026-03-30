
using Postgrest.Attributes;
using Postgrest.Models;

namespace EmpresaMUDDUA.Models
{
    [Table("contactos")] // Esto le dice que use la tabla que creamos en Supabase
    public class Contacto : BaseModel
    {
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("empresa")]
        public string? Empresa { get; set; }

        [Column("asunto")]
        public string Asunto { get; set; } = string.Empty;

        [Column("mensaje")]
        public string Mensaje { get; set; } = string.Empty;
    }
}