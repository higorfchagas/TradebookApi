using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradebookApi.DTO;
using TradebookApi.Models;

namespace TradebookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly TradebookAppContext _db;

        public LivroController(TradebookAppContext context)
        {
            _db = context;
        }

        // GET: api/Livro/GetLivros
        [HttpGet]
        [Route("getlivro")]
        public async Task<IQueryable<LivroDTO>> GetLivros()
        {
            var livros = from y in _db.Livros
                         select new LivroDTO()
                         {
                             IdLivro = y.IdLivro,
                             Descricao = y.Descricao,
                             Autor = y.Autor,
                             DataLancamento = y.DataLancamento,
                             Quantidade = y.Quantidade,
                             UrlImagem = y.UrlImagem,
                             IdCategoriaLivro = y.IdCategoriaLivro,
                             IdUsuario = y.IdUsuario,
                             IdTroca = y.IdTroca,
                         };

            return livros;
        }

        // GET: api/Livro/GetLivro/1
        [HttpGet("getlivro/{id}")]
        public async Task<IQueryable<LivroDTO>> GetLivro(int id)
        {

            var livros = from y in _db.Livros
                         .Where(x => x.IdLivro == id)
                         select new LivroDTO()
                         {
                             IdLivro = y.IdLivro,
                             Descricao = y.Descricao,
                             Autor = y.Autor,
                             DataLancamento = y.DataLancamento,
                             Quantidade = y.Quantidade,
                             UrlImagem = y.UrlImagem,
                             IdCategoriaLivro = y.IdCategoriaLivro,
                             IdUsuario = y.IdUsuario,
                             IdTroca = y.IdTroca,
                         };

            if (livros.Any())
                return livros;
            else
                return null;
        }

        [HttpPost]
        [Route("cadastrarlivro")]
        public async Task<ActionResult<Livro>> CadastrarLivro(Livro livro)
        {
            try
            {
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    _db.Livros.Add(livro);
                    await _db.SaveChangesAsync();

                    return livro;
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível criar o usuário!");
            }
        }

        [HttpPut("alterarlivro/{id}")]
        public async Task<IActionResult> AlterarLivro(int id, Livro livro)
        {
            if (id != livro.IdLivro)
            {
                return BadRequest("O livro não foi encontrado");
            }

            _db.Entry(livro).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
                {
                    return NotFound("Não foi possível executar a operação.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Livro/5
        [HttpDelete("deletarlivro/{id}")]
        public async Task<ActionResult<Livro>> DeletarLivro(int id)
        {
            var livro = await _db.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _db.Livros.Remove(livro);
            await _db.SaveChangesAsync();

            return livro;
        }

        private bool LivroExists(int id)
        {
            return _db.Livros.Any(e => e.IdLivro == id);
        }
    }
}
