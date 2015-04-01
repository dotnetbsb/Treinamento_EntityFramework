using System.Collections.Generic;

namespace CafeA4.Entidades
{
    public class ClubeDeLeitura
    {
        public long ClubeDeLeituraId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Livro LivroAtual { get; set; }
        public ICollection<HistoricoDeLeitura> HistoricoDeLeitura { get; set; }
        public ICollection<Leitor> Participantes { get; set; }
    }
}