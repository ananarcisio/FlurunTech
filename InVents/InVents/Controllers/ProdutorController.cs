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
    public class ProdutorController : Controller
    {
        private readonly InVentsContext _context;

        public ProdutorController(InVentsContext context)
        {
            _context = context;
        }

        // GET: Produtor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtor.ToListAsync());
        }

        // GET: Produtor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtor = await _context.Produtor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtor == null)
            {
                return NotFound();
            }

            return View(produtor);
        }

        // GET: Produtor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,EmpresaId,Email,Cargo,Telefone")] Produtor produtor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtor);
        }

        // GET: Produtor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtor = await _context.Produtor.FindAsync(id);
            if (produtor == null)
            {
                return NotFound();
            }
            return View(produtor);
        }

        // POST: Produtor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,EmpresaId,Email,Cargo,Telefone")] Produtor produtor)
        {
            if (id != produtor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutorExists(produtor.Id))
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
            return View(produtor);
        }

        // GET: Produtor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtor = await _context.Produtor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtor == null)
            {
                return NotFound();
            }

            return View(produtor);
        }


        // POST: Produtor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtor = await _context.Produtor.FindAsync(id);
            if (produtor != null)
            {
                _context.Produtor.Remove(produtor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutorExists(int id)
        {
            return _context.Produtor.Any(e => e.Id == id);
        }


        // GET: Produtor/AddFornecedor/5
        public async Task<IActionResult> AddFornecedor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtor = await _context.Produtor.FindAsync(id);
            if (produtor == null)
            {
                return NotFound();
            }

            // Buscar a lista de fornecedores disponíveis
            var fornecedores = await _context.Fornecedor.ToListAsync();

            // Exibir fornecedores na view
            ViewData["Fornecedores"] = new SelectList(fornecedores, "Id", "Nome");

            return View(produtor);
        }

        // POST: Produtor/AddFornecedor/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFornecedor(int id, int fornecedorId)
        {
            var produtor = await _context.Produtor
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produtor == null)
            {
                return NotFound();
            }

            // Verifica se a lista de fornecedores contratados existe
            if (produtor.FornecedoresContratados == null)
            {
                produtor.FornecedoresContratados = new List<int>();
            }

            // Adicionar fornecedor ao produtor (evitar duplicação)
            if (!produtor.FornecedoresContratados.Contains(fornecedorId))
            {
                produtor.FornecedoresContratados.Add(fornecedorId);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: Produtor/FornecedoresContratados/5
        public async Task<IActionResult> FornecedoresContratados(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Buscar o produtor sem usar o Include para FornecedoresContratados
            var produtor = await _context.Produtor
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produtor == null)
            {
                return NotFound();
            }

            // Verificar se o produtor tem fornecedores contratados
            if (produtor.FornecedoresContratados == null || produtor.FornecedoresContratados.Count == 0)
            {
                return NotFound("Nenhum fornecedor contratado encontrado.");
            }

            // Buscar fornecedores com base na lista de IDs
            var fornecedoresContratados = await _context.Fornecedor
                .Where(f => produtor.FornecedoresContratados.Contains(f.Id))
                .ToListAsync();

            return View(fornecedoresContratados);  // Passa a lista de fornecedores para a view
        }


    }
}
