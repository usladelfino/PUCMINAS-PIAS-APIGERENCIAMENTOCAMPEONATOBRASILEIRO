using System;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class ReadTimeDto
    {
        public int Id { get; internal set; }
        public string Nome { get; set; }
        public string Localidade { get; set; }
        public Object Jogadores { get; set; }
    }

}
