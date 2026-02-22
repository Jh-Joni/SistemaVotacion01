using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaVotacion01;

    public class SistemaVotacionAPIContext : DbContext
    {
        public SistemaVotacionAPIContext (DbContextOptions<SistemaVotacionAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaVotacion01.Usuario> Usuarios { get; set; } = default!;

public DbSet<SistemaVotacion01.Candidato> Candidatos { get; set; } = default!;

public DbSet<SistemaVotacion01.lista> listas { get; set; } = default!;

public DbSet<SistemaVotacion01.Padron> Padrones { get; set; } = default!;

public DbSet<SistemaVotacion01.Rol> Roles { get; set; } = default!;

public DbSet<SistemaVotacion01.ProcesoElectoral> ProcesosElectorales { get; set; } = default!;

public DbSet<SistemaVotacion01.Voto> Votos { get; set; } = default!;

public DbSet<SistemaVotacion01.PartidoPolitico> PartidosPoliticos { get; set; } = default!;
    }
