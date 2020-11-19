using System;
using System.Collections.Generic;

#nullable disable

namespace TradebookApi.Models
{
    public partial class Livro
    {
        public int IdLivro { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public DateTime DataLancamento { get; set; }
        public int Quantidade { get; set; }
        public string UrlImagem { get; set; }
        public int? IdCategoriaLivro { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTroca { get; set; }

        public virtual CategoriasLivro IdCategoriaLivroNavigation { get; set; }
        public virtual Troca IdTrocaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
