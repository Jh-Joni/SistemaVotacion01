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
    public class ProcesoElectoral
    {
        [Key]
        public int Id { get; set; }
        public string NombreProceso { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        [JsonIgnore]
        public List<PartidoPolitico>? PartidoPoliticos { get; set; }

        [JsonIgnore]
        public List<Candidato>? Candidatos { get; set; }

        [JsonIgnore]
        public List<lista>? Listas { get; set; }

        [JsonIgnore]
        public List<Voto>? Votos { get; set; }

        [JsonIgnore]
        public List<Padron>? Padrones { get; set; }
    }
}
