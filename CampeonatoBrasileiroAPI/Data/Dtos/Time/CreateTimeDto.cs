using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class CreateTimeDto
    {
        public string Nome { get; set; }

        public string Localidade { get; set; }
    }

}
