using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion01
{
    public class lista
    {
        [Key]
        public int Id { get; set; }
        public string NombreLista { get; set; }
       

        public int IdProceso { get; set; }
        public ProcesoElectoral? ProcesoElectoral { get; set; }
         public int IdPartido { get; set; }
        public PartidoPolitico? PartidosPoliticos { get; set; }
        public int IdCandidato { get; set; }
        public Candidato ?Candidato { get; set; }
    }
}
