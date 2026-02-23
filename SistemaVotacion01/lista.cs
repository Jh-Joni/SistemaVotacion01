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
       

        public int ProcesoElectoralId { get; set; }
        public ProcesoElectoral? ProcesosElectorales { get; set; }
         public int PartidoPoliticoId { get; set; }
        public PartidoPolitico? PartidosPoliticos { get; set; }
        public int CandidatoId { get; set; }
        public Candidato ?Candidatos { get; set; }
    }
}
