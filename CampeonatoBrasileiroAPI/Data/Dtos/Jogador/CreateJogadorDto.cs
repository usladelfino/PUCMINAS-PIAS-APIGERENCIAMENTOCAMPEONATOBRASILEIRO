using CampeonatoBrasileiroAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class CreateJogadorDto
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public String Pais { get; set; }

        public int TimeId { get; set; }
    }
}
