using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CampeonatoBrasileiroAPI.Models.Participacao;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class UpdateParticipacaoDto
    {
        public int Gols { get; set; }
        public eResultado Resultado { get; set; }
    }
}
