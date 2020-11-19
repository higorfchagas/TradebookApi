using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TradebookApi.Models
{
    public partial class TradebookAppContext : DbContext
    {
        public TradebookAppContext()
        {
        }

        public TradebookAppContext(DbContextOptions<TradebookAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriasLivro> CategoriasLivros { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }
        public virtual DbSet<Troca> Trocas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=DESKTOP-7SVO5T2\\\\\\\\HIGOR;Initial Catalog=TradebookApp;Data Source=.\\SQLEXPRESS;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriasLivro>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaLivro);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.IdLivro);

                entity.Property(e => e.DataLancamento).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.HasOne(d => d.IdCategoriaLivroNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdCategoriaLivro)
                    .HasConstraintName("FK_Livros_CategoriaLivro");

                entity.HasOne(d => d.IdTrocaNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdTroca)
                    .HasConstraintName("FK_Livros_Troca");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Livros_Usuario");
            });

            modelBuilder.Entity<Troca>(entity =>
            {
                entity.HasKey(e => e.IdTroca);

                entity.ToTable("Troca");

                entity.HasOne(d => d.IdUsuarioTrocaNavigation)
                    .WithMany(p => p.Trocas)
                    .HasForeignKey(d => d.IdUsuarioTroca)
                    .HasConstraintName("FK_Livros_TrocaUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
