using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Models
{
    public enum eEvento
    {
        [Display(Name = "Início de Partida")]
        Inicio = 0,
        [Display(Name = "Gol")]
        Gol = 1,
        [Display(Name = "Intervalo")]
        Intervalo = 2,
        [Display(Name = "Acréscimo")]
        Acrescimo = 3,
        [Display(Name = "Substituicao")]
        Substituicao = 4,
        [Display(Name = "Advertência")]
        Advertencia = 5,
        [Display(Name = "Fim de Partida")]
        Fim = 6
    }

    public class Evento
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        public eEvento Tipo { get; set; }
        public String Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public virtual Partida Partida { get; set; }
        public int PartidaId { get; set; }
    }
}
