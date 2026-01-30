using Microsoft.EntityFrameworkCore;
using Sistemas_de_emprestimos_de_livro.Models;

namespace Sistemas_de_emprestimos_de_livro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Livro> Livro { get; set; } = default!;
        public DbSet<Usuario> Usuario { get; set; } = default!;
        public DbSet<Emprestimo> Emprestimo { get; set; } = default!;
        public DbSet<Renovacao> Renovacao { get; set; } = default!;
        public DbSet<Categoria> Categoria { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais podem ser feitas aqui, se necessário
            modelBuilder.Entity<Livro>().ToTable("Livro");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Emprestimo>().ToTable("Emprestimo");
            modelBuilder.Entity<Renovacao>().ToTable("Renovacao");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
        }
    }
}
