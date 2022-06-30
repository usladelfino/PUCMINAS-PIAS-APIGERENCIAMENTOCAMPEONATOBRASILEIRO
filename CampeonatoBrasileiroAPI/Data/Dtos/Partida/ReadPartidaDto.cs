using CampeonatoBrasileiroAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class ReadPartidaDto
    {
        public int Id { get; internal set; }
        public Object Torneio { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public Object TimesParticipantes { get; set; }
        public Object Eventos { get; set; }
    }
}
