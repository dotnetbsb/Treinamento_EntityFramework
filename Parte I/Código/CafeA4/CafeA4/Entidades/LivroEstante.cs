namespace CafeA4.Entidades
{
    public class LivroEstante
    {
        public long LivroEstanteId { get; set; }
        public Livro Livro { get; set; }
        public LivroEstanteStatus Status { get; set; }
        public Leitor Leitor { get; set; }
    }
}