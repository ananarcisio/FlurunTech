using ControleDeVinil.Shared.Dados.Banco;
using ControleDeVinil.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeVinil.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotaController : ControllerBase
	{
		private readonly DAO<Nota> NotaDAO;

		public NotaController(Contexto contexto)
		{
            NotaDAO = new DAO<Nota>(contexto);
		}

		[HttpGet]
		public IEnumerable<Nota> ObterTodos()
		{
			return NotaDAO.ObterTodos();
		}

		[HttpGet("{id}")]
		public IActionResult ObterPorId(int id)
		{
			var nota = NotaDAO.LocalizarPor(p => p.Id == id);
			if (nota != null)
			{
				return Ok(nota);
			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult Criar(Nota novoNota)
		{
			if (novoNota == null)
			{
				return BadRequest("Dados inválidos");
			}

            NotaDAO.Criar(novoNota);

			return CreatedAtAction(nameof(ObterPorId), new { id = novoNota.Id }, novoNota);
		}

		[HttpPut("{id}")]
		public IActionResult Atualizar(int id, Nota notaAtualizado)
		{
			var nota = NotaDAO.LocalizarPor(p => p.Id == id);
			if (nota == null)
			{
				return NotFound();
			}

            NotaDAO.Atualizar(nota);

			return Ok(nota);
		}

		[HttpDelete("{id}")]
		public IActionResult Deletar(int id)
		{
			var nota = NotaDAO.LocalizarPor(p => p.Id == id);
			if (nota == null)
			{
				return NotFound();
			}

			NotaDAO.Excluir(nota);

			return Ok(nota);
		}
	}
}