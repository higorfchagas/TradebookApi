using System;
using System.Collections.Generic;

#nullable disable

namespace TradebookApi.Models
{
    public partial class CategoriasLivro
    {
        public CategoriasLivro()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdCategoriaLivro { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
