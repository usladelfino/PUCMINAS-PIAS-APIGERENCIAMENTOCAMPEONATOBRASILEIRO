using CampeonatoBrasileiroAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class CreateEventoDto
    {
        public String Descricao { get; set; }
        public DateTime DataHora { get; set; }
    }
}
