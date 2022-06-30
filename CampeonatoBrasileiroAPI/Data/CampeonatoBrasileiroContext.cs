using CampeonatoBrasileiroAPI.Data.Dtos;
using CampeonatoBrasileiroAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Data
{
    public class CampeonatoBrasileiroContext : DbContext
    {
        public CampeonatoBrasileiroContext(DbContextOptions<CampeonatoBrasileiroContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Torneio>()
                .HasIndex(torneio => new {torneio.Serie, torneio.Ano})
                .IsUnique();

            builder.Entity<Torneio>()
                .HasMany<Time>(torneio => torneio.Times)
                .WithMany(time => time.Torneios);

            builder.Entity<Participacao>()
                .HasOne<Partida>(participacao => participacao.Partida)
                .WithMany(partida => partida.TimesParticipantes)
                .HasForeignKey(participacao => participacao.PartidaId);

            builder.Entity<Participacao>()
                .HasOne<Time>(participacao => participacao.Time)
                .WithMany(time => time.ParticipacoesEmPartidas)
                .HasForeignKey(participacao => participacao.TimeId);

            builder.Entity<Partida>()
                .HasOne<Torneio>(partida => partida.Torneio)
                .WithMany(torneio => torneio.Partidas)
                .HasForeignKey(partida => partida.TorneioId);

            builder.Entity<Evento>()
                .HasIndex(evento => new { evento.Tipo, evento.DataHora, evento.PartidaId })
                .IsUnique();

            builder.Entity<Evento>()
                .HasOne<Partida>(evento => evento.Partida)
                .WithMany(partida => partida.Eventos)
                .HasForeignKey(evento => evento.PartidaId);

            builder.Entity<Jogador>()
                .HasOne<Time>(j => j.Time)
                .WithMany(t => t.Jogadores)
                .HasForeignKey(j => j.TimeId);

            builder.Entity<Transferencia>()
                .HasOne<Jogador>(t => t.Jogador)
                .WithMany(j => j.Transferencias)
                .HasForeignKey(t => t.JogadorId);

            builder.Entity<Transferencia>()
                .HasOne<Time>(transferencia => transferencia.TimeOrigem)
                .WithMany(time => time.TransferenciasOrigem)
                .HasForeignKey(transferencia => transferencia.TimeOrigemId);

            builder.Entity<Transferencia>()
                .HasOne<Time>(transferencia => transferencia.TimeDestino)
                .WithMany(time => time.TransferenciasDestino)
                .HasForeignKey(transferencia => transferencia.TimeDestinoId);

        }

        public DbSet<Torneio> Torneios { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Participacao> Participacoes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
    }
}
