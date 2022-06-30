using CampeonatoBrasileiroAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class CreateTransferenciaDto
    {
        public int JogadorId { get; set; }

        public int TimeOrigemId { get; set; }

        public int TimeDestinoId { get; set; }

        public DateTime Data { get; set; }

        public Decimal Valor { get; set; }
    }
}
