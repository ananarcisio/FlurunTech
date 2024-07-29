using ControleDeVinil.Shared.Dados.Banco;
using ControleDeVinil.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeVinil.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FornecedorController : ControllerBase
	{
		private readonly DAO<Fornecedor> FornecedorDAO;

		public FornecedorController(Contexto contexto)
		{
			FornecedorDAO = new DAO<Fornecedor>(contexto);
		}

		[HttpGet]
		public IEnumerable<Fornecedor> ObterTodos()
		{
			return FornecedorDAO.ObterTodos();
		}

		[HttpGet("{id}")]
		public IActionResult ObterPorId(int id)
		{
			var fornecedor = FornecedorDAO.LocalizarPor(f => f.Id == id);
			if (fornecedor != null)
			{
				return Ok(fornecedor);
			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult Criar( Fornecedor novoFornecedor)
		{
			if (novoFornecedor == null)
			{
				return BadRequest("Dados inválidos");
			}

			FornecedorDAO.Criar(novoFornecedor);

			return CreatedAtAction(nameof(ObterPorId), new { id = novoFornecedor.Id }, novoFornecedor);
		}

		[HttpPut("{id}")]
		public IActionResult Atualizar(int id, Fornecedor fornecedorAtualizado)
		{
			var fornecedor = FornecedorDAO.LocalizarPor(f => f.Id == id);
			if (fornecedor == null)
			{
				return NotFound();
			}

			FornecedorDAO.Atualizar(fornecedor);

			return Ok(fornecedor);
		}

		[HttpDelete("{id}")]
		public IActionResult Deletar(int id)
		{
			var fornecedor = FornecedorDAO.LocalizarPor(p => p.Id == id);
			if (fornecedor == null)
			{
				return NotFound();
			}

			FornecedorDAO.Excluir(fornecedor);

			return Ok(fornecedor);
		}
	}
}
