using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion01
{
    public class ProcesoElectoral
    {
        [Key]
        public int Id { get; set; }
        public string NombreProceso { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }

           public List<PartidoPolitico>? Partidos { get; set; }
            public List<Candidato>? Candidatos { get; set; }
            public List<lista>? Listas { get; set; }
        public List<Voto>? Votos { get; set; }
        public List<Padron>? Padrones { get; set; }

    }
}
