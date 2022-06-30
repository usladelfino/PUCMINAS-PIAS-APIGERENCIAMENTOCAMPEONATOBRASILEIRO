using CampeonatoBrasileiroAPI.Data.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CampeonatoBrasileiroAPI.Models
{
    public class Partida
    {
        
        [Key]
        [Required]
        public int Id { get; internal set; }
        public virtual Torneio Torneio { get; set; }
        public int TorneioId { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        [JsonIgnore]
        public virtual ICollection<Evento> Eventos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Participacao> TimesParticipantes { get; set; }

    }
}
