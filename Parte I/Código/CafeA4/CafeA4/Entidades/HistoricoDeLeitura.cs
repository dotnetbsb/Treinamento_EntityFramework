using System;

namespace CafeA4.Entidades
{
    public class HistoricoDeLeitura
    {
        public long HistoricoDeLeituraId { get; set; }
        public Livro Livro { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public ClubeDeLeitura ClubeDeLeitura { get; set; }
    }
}
