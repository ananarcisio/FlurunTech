using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InVents.Data;
using InVents.Models;

namespace InVents.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly InVentsContext _context;

        public FornecedorController(InVentsContext context)
        {
            _context = context;
        }

        // GET: Fornecedor/Search
        public IActionResult Search()
        {
            return View();
        }

        // POST: Fornecedor/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(int id)
        {
            var fornecedor = await _context.Fornecedor.FirstOrDefaultAsync(f => f.Id == id);
            if (fornecedor == null)
            {
                ModelState.AddModelError(string.Empty, "Fornecedor não encontrado.");
                return View();
            }

            return RedirectToAction("Details", new { id = fornecedor.Id });
        }

        // GET: Fornecedor
        public async Task<IActionResult> Index()
        {
            var fornecedores = await _context.Fornecedor.ToListAsync();

            foreach (var fornecedor in fornecedores)
            {
                // Calcular a média das notas
                var mediaNota = await _context.Nota
                                              .Where(n => n.FornecedorId == fornecedor.Id)
                                              .AverageAsync(n => n.NotaValor ?? 0);
                fornecedor.MediaNota = mediaNota; // Adicionar a média de nota ao objeto fornecedor
            }

            return View(fornecedores);
        }


        // GET: Fornecedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor
                .FirstOrDefaultAsync(m => m.Id == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            // Passa o fornecedor como uma lista, mesmo que seja só um
            var fornecedorList = new List<Fornecedor> { fornecedor };

            return View(fornecedorList);  // Passa a lista de fornecedores para a view
        }


        // GET: Fornecedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeFantasia,RazaoSocial,CNPJ,Endereco,Numero,Complemento,Bairro,Cidade,Estado,Setor,Email,Imagem")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeFantasia,RazaoSocial,CNPJ,Endereco,Numero,Complemento,Bairro,Cidade,Estado,Setor,Email,Imagem")] Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedor.Remove(fornecedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedor.Any(e => e.Id == id);
        }

    }
}
