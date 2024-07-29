using ControleDeVinil.Shared.Dados.Banco;
using ControleDeVinil.Shared.Modelos.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeVinil.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpresaController : ControllerBase
	{
		private readonly DAO<Empresa> EmpresaDAO;

		public EmpresaController(Contexto contexto)
		{
            EmpresaDAO = new DAO<Empresa>(contexto);
		}

		[HttpGet]
		public IEnumerable<Empresa> ObterTodos()
		{
			return EmpresaDAO.ObterTodos();
		}

		[HttpGet("{id}")]
		public IActionResult ObterPorId(int id)
		{
			var empresa = EmpresaDAO.LocalizarPor(p => p.Id == id);
			if (empresa != null)
			{
				return Ok(empresa);
			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult Criar(Empresa novoEmpresa)
		{
			if (novoEmpresa == null)
			{
				return BadRequest("Dados inválidos");
			}

            EmpresaDAO.Criar(novoEmpresa);

			return CreatedAtAction(nameof(ObterPorId), new { id = novoEmpresa.Id }, novoEmpresa);
		}

		[HttpPut("{id}")]
		public IActionResult Atualizar(int id, Empresa empresaAtualizado)
		{
			var empresa = EmpresaDAO.LocalizarPor(p => p.Id == id);
			if (empresa == null)
			{
				return NotFound();
			}

            EmpresaDAO.Atualizar(empresa);

			return Ok(empresa);
		}

		[HttpDelete("{id}")]
		public IActionResult Deletar(int id)
		{
			var empresa = EmpresaDAO.LocalizarPor(p => p.Id == id);
			if (empresa == null)
			{
				return NotFound();
			}

            EmpresaDAO.Excluir(empresa);

			return Ok(empresa);
		}
	}
}