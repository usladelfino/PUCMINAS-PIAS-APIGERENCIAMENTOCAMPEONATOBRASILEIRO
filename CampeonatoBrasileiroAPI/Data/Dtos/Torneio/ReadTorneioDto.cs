using CampeonatoBrasileiroAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class ReadTorneioDto
    {
        public int Id { get; internal set; }
        public int Ano { get; set; }
        public string Serie { get; set; }
        public Object Times { get; set; }
        public Object Partidas { get; set; }
    }
}
