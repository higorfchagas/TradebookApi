using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradebookApi.Models;

namespace TradebookApi.DTO
{
        public class LivroDTO
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

    }
}
