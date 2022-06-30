using CampeonatoBrasileiroAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class UpdateTorneioDto
    {
        public ICollection<Time> Times { get; set; }
    }
}
