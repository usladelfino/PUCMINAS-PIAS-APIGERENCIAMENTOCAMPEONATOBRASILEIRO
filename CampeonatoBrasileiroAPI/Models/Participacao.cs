using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampeonatoBrasileiroAPI.Models
{
    public class Participacao
    {
        public enum eResultado
        {
            [Display(Name = "Derrota")]
            Derrota = 0,
            [Display(Name = "Empate")]
            Empate = 1,
            [Display(Name = "Vitória")]
            Vitoria = 3
        }

        [Key]
        [Required]
        public int Id { get; internal set; }
        public virtual Partida Partida { get; set; }
        public int PartidaId { get; set; }
        public virtual Time Time { get; set; }
        public int TimeId { get; set; }
        public int Gols { get; set; }
        public eResultado Resultado { get; set; }
    }
}
