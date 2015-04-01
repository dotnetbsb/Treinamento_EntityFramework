using CafeA4.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CafeA4.Persistencia
{
    public class CafeA4DbContext : DbContext
    {
        public CafeA4DbContext() : base("CafeA4") { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroEstante> LivrosEstante { get; set; }
        public DbSet<Leitor> Leitores { get; set; }
        public DbSet<ClubeDeLeitura> ClubesDeLeitura { get; set; }
        public DbSet<HistoricoDeLeitura> HistoricoLeitura { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //! Muda a forma de inicialização do banco de dados e adicionar alguns registros iniciais.
            Database.SetInitializer(new CafeA4Initializer());
            //! Remove a plularização dos nomes das tabelas.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
