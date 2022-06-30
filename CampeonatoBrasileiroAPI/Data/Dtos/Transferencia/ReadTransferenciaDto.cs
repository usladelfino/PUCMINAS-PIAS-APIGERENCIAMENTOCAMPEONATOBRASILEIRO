using System;

namespace CampeonatoBrasileiroAPI.Data.Dtos
{
    public class ReadTransferenciaDto
    {
        public int Id { get; internal set; }
        public  Object Jogador { get; set; }
        public Object TimeOrigem { get; set; }
        public Object TimeDestino { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
    }
}
