using ControleDeVinil.Shared.Dados.Banco;
using ControleDeVinil.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeVinil.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutorController : ControllerBase
	{
		private readonly DAO<Produtor> ProdutorDAO;

		public ProdutorController(Contexto contexto)
		{
			ProdutorDAO = new DAO<Produtor>(contexto);
		}

		[HttpGet]
		public IEnumerable<Produtor> ObterTodos()
		{
			return ProdutorDAO.ObterTodos();
		}

		[HttpGet("{id}")]
		public IActionResult ObterPorId(int id)
		{
			var produtor = ProdutorDAO.LocalizarPor(p => p.Id == id);
			if (produtor != null)
			{
				return Ok(produtor);
			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult Criar([FromBody] Produtor novoProdutor)
		{
			if (novoProdutor == null)
			{
				return BadRequest("Dados inválidos");
			}

			ProdutorDAO.Criar(novoProdutor);

			return CreatedAtAction(nameof(ObterPorId), new { id = novoProdutor.Id }, novoProdutor);
		}

		[HttpPut("{id}")]
		public IActionResult Atualizar(int id, [FromBody] Produtor produtorAtualizado)
		{
			var produtor = ProdutorDAO.LocalizarPor(p => p.Id == id);
			if (produtor == null)
			{
				return NotFound();
			}

			ProdutorDAO.Atualizar(produtor);

			return Ok(produtor);
		}

		[HttpDelete("{id}")]
		public IActionResult Deletar(int id)
		{
			var produtor = ProdutorDAO.LocalizarPor(p => p.Id == id);
			if (produtor == null)
			{
				return NotFound();
			}

			ProdutorDAO.Excluir(produtor);

			return Ok(produtor);
		}
	}
}
