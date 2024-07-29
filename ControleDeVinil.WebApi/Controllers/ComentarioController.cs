using ControleDeVinil.Shared.Dados.Banco;
using ControleDeVinil.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeVinil.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ComentarioController : ControllerBase
	{
		private readonly DAO<Comentario> ComentarioDAO;

		public ComentarioController(Contexto contexto)
		{
            ComentarioDAO = new DAO<Comentario>(contexto);
		}

		[HttpGet]
		public IEnumerable<Comentario> ObterTodos()
		{
			return ComentarioDAO.ObterTodos();
		}

		[HttpGet("{id}")]
		public IActionResult ObterPorId(int id)
		{
			var comentario = ComentarioDAO.LocalizarPor(p => p.Id == id);
			if (comentario != null)
			{
				return Ok(comentario);
			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult Criar(Comentario novoComentario)
		{
			if (novoComentario == null)
			{
				return BadRequest("Dados inválidos");
			}

			ComentarioDAO.Criar(novoComentario);

			return CreatedAtAction(nameof(ObterPorId), new { id = novoComentario.Id }, novoComentario);
		}

		[HttpPut("{id}")]
		public IActionResult Atualizar(int id, Comentario comentarioAtualizado)
		{
			var comentario = ComentarioDAO.LocalizarPor(p => p.Id == id);
			if (comentario == null)
			{
				return NotFound();
			}

			ComentarioDAO.Atualizar(comentario);

			return Ok(comentario);
		}

		[HttpDelete("{id}")]
		public IActionResult Deletar(int id)
		{
			var comentario = ComentarioDAO.LocalizarPor(p => p.Id == id);
			if (comentario == null)
			{
				return NotFound();
			}

			ComentarioDAO.Excluir(comentario);

			return Ok(comentario);
		}
	}
}