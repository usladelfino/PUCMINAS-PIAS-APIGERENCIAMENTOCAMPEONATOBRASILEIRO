using System;
using static CampeonatoBrasileiroAPI.Models.Participacao;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class ReadParticipacaoDto
    {
        public int Id { get; internal set; }
        public Object Partida { get; set; }
        public Object Time { get; set; }
        public int Gols { get; set; }
        public eResultado Resultado { get; set; }
    }
}
