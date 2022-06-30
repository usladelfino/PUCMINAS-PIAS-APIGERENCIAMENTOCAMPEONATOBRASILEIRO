using CampeonatoBrasileiroAPI.Models;
using System;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class ReadJogadorDto
    {
        public int Id { get; internal set; }
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public String Pais { get; set; }

        public Object Time { get; set; }

        public Object Transferencias { get; set; }
    }
}
