using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion01
{
    public class Voto
    {
        [Key]
        public int Id { get; set; }

        public int IdCandidato { get; set; }

        public int IdProceso { get; set; }
            public Candidato? Candidato { get; set; }
            public ProcesoElectoral? ProcesosElectorales { get; set; }

        public DateTime FechaVoto { get; set; } = DateTime.Now;
    }
}
