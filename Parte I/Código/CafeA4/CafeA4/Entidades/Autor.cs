using System.Collections.Generic;

namespace CafeA4.Entidades
{
    public class Autor
    {
        public long AutorId { get; set; }
        public string Nome { get; set; }
        public ICollection<Livro> Obra { get; set; }
    }
}