using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
        public string simboloUrl { get; set; }
         public int ProcesoElectoralId { get; set; }

        public List<lista>? Listas { get; set; }
    }
}
