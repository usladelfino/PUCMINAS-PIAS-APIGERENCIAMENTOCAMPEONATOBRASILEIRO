// <auto-generated />
using System;
using CampeonatoBrasileiroAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CampeonatoBrasileiroAPI.Migrations
{
    [DbContext(typeof(CampeonatoBrasileiroContext))]
    partial class CampeonatoBrasileiroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<int>("PartidaId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartidaId");

                    b.HasIndex("Tipo", "DataHora", "PartidaId")
                        .IsUnique();

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Jogador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TimeId");

                    b.ToTable("Jogadores");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Participacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Gols")
                        .HasColumnType("int");

                    b.Property<int>("PartidaId")
                        .HasColumnType("int");

                    b.Property<int>("Resultado")
                        .HasColumnType("int");

                    b.Property<int>("TimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartidaId");

                    b.HasIndex("TimeId");

                    b.ToTable("Participacoes");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Partida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<string>("Local")
                        .HasColumnType("text");

                    b.Property<int>("TorneioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TorneioId");

                    b.ToTable("Partidas");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Localidade")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Torneio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("Serie", "Ano")
                        .IsUnique();

                    b.ToTable("Torneios");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Transferencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<int>("JogadorId")
                        .HasColumnType("int");

                    b.Property<int>("TimeDestinoId")
                        .HasColumnType("int");

                    b.Property<int>("TimeOrigemId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("JogadorId");

                    b.HasIndex("TimeDestinoId");

                    b.HasIndex("TimeOrigemId");

                    b.ToTable("Transferencias");
                });

            modelBuilder.Entity("TimeTorneio", b =>
                {
                    b.Property<int>("TimesId")
                        .HasColumnType("int");

                    b.Property<int>("TorneiosId")
                        .HasColumnType("int");

                    b.HasKey("TimesId", "TorneiosId");

                    b.HasIndex("TorneiosId");

                    b.ToTable("TimeTorneio");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Evento", b =>
                {
                    b.HasOne("CampeonatoBrasileiroAPI.Models.Partida", "Partida")
                        .WithMany("Eventos")
                        .HasForeignKey("PartidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partida");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Jogador", b =>
                {
                    b.HasOne("CampeonatoBrasileiroAPI.Models.Time", "Time")
                        .WithMany("Jogadores")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Time");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Participacao", b =>
                {
                    b.HasOne("CampeonatoBrasileiroAPI.Models.Partida", "Partida")
                        .WithMany("TimesParticipantes")
                        .HasForeignKey("PartidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampeonatoBrasileiroAPI.Models.Time", "Time")
                        .WithMany("ParticipacoesEmPartidas")
                        .HasForeignKey("TimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partida");

                    b.Navigation("Time");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Partida", b =>
                {
                    b.HasOne("CampeonatoBrasileiroAPI.Models.Torneio", "Torneio")
                        .WithMany("Partidas")
                        .HasForeignKey("TorneioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Torneio");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Transferencia", b =>
                {
                    b.HasOne("CampeonatoBrasileiroAPI.Models.Jogador", "Jogador")
                        .WithMany("Transferencias")
                        .HasForeignKey("JogadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampeonatoBrasileiroAPI.Models.Time", "TimeDestino")
                        .WithMany("TransferenciasDestino")
                        .HasForeignKey("TimeDestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampeonatoBrasileiroAPI.Models.Time", "TimeOrigem")
                        .WithMany("TransferenciasOrigem")
                        .HasForeignKey("TimeOrigemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jogador");

                    b.Navigation("TimeDestino");

                    b.Navigation("TimeOrigem");
                });

            modelBuilder.Entity("TimeTorneio", b =>
                {
                    b.HasOne("CampeonatoBrasileiroAPI.Models.Time", null)
                        .WithMany()
                        .HasForeignKey("TimesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampeonatoBrasileiroAPI.Models.Torneio", null)
                        .WithMany()
                        .HasForeignKey("TorneiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Jogador", b =>
                {
                    b.Navigation("Transferencias");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Partida", b =>
                {
                    b.Navigation("Eventos");

                    b.Navigation("TimesParticipantes");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Time", b =>
                {
                    b.Navigation("Jogadores");

                    b.Navigation("ParticipacoesEmPartidas");

                    b.Navigation("TransferenciasDestino");

                    b.Navigation("TransferenciasOrigem");
                });

            modelBuilder.Entity("CampeonatoBrasileiroAPI.Models.Torneio", b =>
                {
                    b.Navigation("Partidas");
                });
#pragma warning restore 612, 618
        }
    }
}
