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
    public class lista
    {
        [Key]
        public int Id { get; set; }
        public string NombreLista { get; set; }

        public int ProcesoElectoralId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(ProcesoElectoralId))]
        public ProcesoElectoral? ProcesosElectorales { get; set; }

        public int PartidoPoliticoId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(PartidoPoliticoId))]
        public PartidoPolitico? PartidosPoliticos { get; set; }

        public int CandidatoId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CandidatoId))]
        public Candidato? Candidatos { get; set; }
    }
}
