using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CampeonatoBrasileiroAPI.Models
{
    public class Transferencia
    {
        [Key]
        [Required]
        public int Id { get; internal set; }

        [Required(ErrorMessage = "O campo Jogador é obrigatório")]
        public virtual Jogador Jogador { get; set; }
        public int JogadorId { get; set; }

        [Required(ErrorMessage = "O campo TimeOrigem é obrigatório")]
        public virtual Time TimeOrigem { get; set; }
        public int TimeOrigemId { get; set; }

        [Required(ErrorMessage = "O campo TimeDestino é obrigatório")]
        public virtual Time TimeDestino { get; set; }
        public int TimeDestinoId { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório")]
        public Decimal Valor { get; set; }

    }
}
