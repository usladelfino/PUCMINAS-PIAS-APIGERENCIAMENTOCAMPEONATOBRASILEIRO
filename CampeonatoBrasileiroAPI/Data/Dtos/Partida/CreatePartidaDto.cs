using CampeonatoBrasileiroAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class CreatePartidaDto
    {
        public DateTime Data { get; set; }
        public string Local { get; set; }
    }
}
