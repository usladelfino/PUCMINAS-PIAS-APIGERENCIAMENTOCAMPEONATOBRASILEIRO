using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Models
{
    public class Jogador
    {
        [Key]
        [Required]
        public int Id { get; internal set; }
        
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(150, ErrorMessage = "O Nome deve possuir no máximo 150 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo DataNascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Pais é obrigatório")]
        public String Pais { get; set; }

        public virtual Time Time { get; set; }
        
        public int TimeId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Transferencia> Transferencias { get; set; }

    }
}
