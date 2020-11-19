using System;
using System.Collections.Generic;

#nullable disable

namespace TradebookApi.Models
{
    public partial class Troca
    {
        public Troca()
        {
            Livros = new HashSet<Livro>();
        }

        public int IdTroca { get; set; }
        public int? IdUsuarioTroca { get; set; }

        public virtual Usuario IdUsuarioTrocaNavigation { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
