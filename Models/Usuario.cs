using System;
using System.Collections.Generic;

#nullable disable

namespace TradebookApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Livros = new HashSet<Livro>();
            Trocas = new HashSet<Troca>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
        public virtual ICollection<Troca> Trocas { get; set; }
    }
}
