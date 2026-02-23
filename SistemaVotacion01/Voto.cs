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

        public int CandidatoId { get; set; }

        public int ProcesoElectoralId { get; set; }
            public Candidato? Candidatos { get; set; }
            public ProcesoElectoral? ProcesosElectorales { get; set; }

        public DateTime FechaVoto { get; set; } = DateTime.Now;
    }
}
