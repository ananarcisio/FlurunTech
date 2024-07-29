using ControleDeVinil.Shared.Dados.Banco;
using ControleDeVinil.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeVinil.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventoController : ControllerBase
	{
		private readonly DAO<Evento> EventoDAO;

		public EventoController(Contexto contexto)
		{
            EventoDAO = new DAO<Evento>(contexto);
		}

		[HttpGet]
		public IEnumerable<Evento> ObterTodos()
		{
			return EventoDAO.ObterTodos();
		}

		[HttpGet("{id}")]
		public IActionResult ObterPorId(int id)
		{
			var evento = EventoDAO.LocalizarPor(p => p.Id == id);
			if (evento != null)
			{
				return Ok(evento);
			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult Criar(Evento novoEvento)
		{
			if (novoEvento == null)
			{
				return BadRequest("Dados inválidos");
			}

            EventoDAO.Criar(novoEvento);

			return CreatedAtAction(nameof(ObterPorId), new { id = novoEvento.Id }, novoEvento);
		}

		[HttpPut("{id}")]
		public IActionResult Atualizar(int id, Evento eventoAtualizado)
		{
			var evento = EventoDAO.LocalizarPor(p => p.Id == id);
			if (evento == null)
			{
				return NotFound();
			}

            EventoDAO.Atualizar(evento);

			return Ok(evento);
		}

		[HttpDelete("{id}")]
		public IActionResult Deletar(int id)
		{
			var evento = EventoDAO.LocalizarPor(p => p.Id == id);
			if (evento == null)
			{
				return NotFound();
			}

            EventoDAO.Excluir(evento);

			return Ok(evento);
		}
	}
}