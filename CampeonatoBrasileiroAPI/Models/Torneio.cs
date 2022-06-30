using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CampeonatoBrasileiroAPI.Models
{
    public class Torneio
    {
        [Key]
        [Required]
        public int Id { get; internal set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo Serie é obrigatório")]
        [StringLength(1, ErrorMessage = "O campo Serie deve possuir no máximo 1 caracter")]
        public string Serie { get; set; }

        [JsonIgnore]
        public virtual ICollection<Time> Times { get; set; }

        [JsonIgnore]
        public virtual ICollection<Partida> Partidas { get; set; }
    }
}
