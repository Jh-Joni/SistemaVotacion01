using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacion01
{
    public class Candidato
    {
        [Key]
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string FotoUrl { get; set; }
     

        public int ProcesoElectoralId  { get; set; }
            public ProcesoElectoral? ProcesosElectorales { get; set; }
        public List <Voto>? Votos { get; set; }

    }
}
