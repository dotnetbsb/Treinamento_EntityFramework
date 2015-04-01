namespace CafeA4.Entidades
{
    public class Livro
    {
        public long LivroId { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public Autor Autor { get; set; }
    }
}