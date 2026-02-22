using System.ComponentModel.DataAnnotations;

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
        public int cedula { get; set; }

         public int RolId { get; set; }
            public Rol? Rol { get; set; }
      
         public List<Padron>? Padrones { get; set; }


    }
}
