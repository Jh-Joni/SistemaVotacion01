using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [Required]
        public int ProcesoElectoralId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ProcesoElectoralId))]
        public ProcesoElectoral? ProcesosElectorales { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(UsuarioId))]
        public Usuario? Usuarios { get; set; }
    }
}
