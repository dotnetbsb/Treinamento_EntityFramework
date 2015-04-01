using System.Collections.Generic;

namespace CafeA4.Entidades
{
    public class Leitor
    {
        public long LeitorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public ICollection<LivroEstante> Estante { get; set; }
        public ICollection<ClubeDeLeitura> ClubesDeLeitura { get; set; }
    }
}