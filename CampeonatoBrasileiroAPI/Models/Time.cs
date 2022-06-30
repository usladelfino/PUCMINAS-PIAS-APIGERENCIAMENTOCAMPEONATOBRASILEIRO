using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CampeonatoBrasileiroAPI.Models
{
    public class Time
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        
        [StringLength(100, ErrorMessage = "O Nome Nome deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }
        
        [StringLength(100, ErrorMessage = "O Nome Localidade deve possuir no máximo 100 caracteres")]
        public string Localidade { get; set; }

        [JsonIgnore]
        public virtual ICollection<Jogador> Jogadores { get; set; }

        [JsonIgnore]
        public virtual ICollection<Transferencia> TransferenciasOrigem { get; set; }

        [JsonIgnore]
        public virtual ICollection<Transferencia> TransferenciasDestino { get; set; }

        [JsonIgnore]
        public virtual ICollection<Torneio> Torneios { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Participacao> ParticipacoesEmPartidas { get; set; }
    }
}
