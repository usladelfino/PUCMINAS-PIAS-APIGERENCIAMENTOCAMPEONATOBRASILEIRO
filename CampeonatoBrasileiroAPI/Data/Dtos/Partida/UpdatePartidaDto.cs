using CampeonatoBrasileiroAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class UpdatePartidaDto
    {
        
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public ICollection<Participacao> TimesParticipantes { get; set; }
    }
}
