using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion01
{
    public class Padron
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool HaVotado { get; set; }

        public string? CodigoAcceso { get; set; }


        [Required, ForeignKey(nameof(Proceso))]
        public int IdProceso { get; set; }


        [Required, ForeignKey(nameof(Usuarios))]
        public int IdUsuario { get; set; }


        public ProcesoElectoral? Proceso { get; set; }

        public Usuario? Usuarios { get; set; }

    }
}
