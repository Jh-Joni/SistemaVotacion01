using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaVotacion01
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int Cedula { get; set; }

        public int RolId { get; set; }

        [JsonIgnore]
        public Rol? Rol { get; set; }

        [JsonIgnore]
        public List<Padron>? Padrones { get; set; }
    }
}
