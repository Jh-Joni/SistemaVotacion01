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
    public class PartidoPolitico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NOmbrePartido { get; set; }

        [Required]
        public string SimboloUrl { get; set; }

        public int ProcesoElectoralId { get; set; }

        [JsonIgnore]
        public List<lista>? Listas { get; set; }
    }
}
