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
    public class EmpresaController : Controller
    {
        private readonly InVentsContext _context;

        public EmpresaController(InVentsContext context)
        {
            _context = context;
        }

        // GET: Empresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empresa.ToListAsync());
        }
        
        // GET: Empresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            // Criar uma lista com apenas a empresa selecionada, já que você quer exibir em formato de tabela.
            var empresaList = new List<Empresa> { empresa };

            return View(empresaList);  // Passa a lista de empresas (com uma única empresa) para a View
        }



        // GET: Empresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Empresa/Search
        public IActionResult Search()
        {
            return View();
        }

        // POST: Empresa/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(int id)
        {
            var empresa = await _context.Empresa.FirstOrDefaultAsync(e => e.Id == id);
            if (empresa == null)
            {
                ModelState.AddModelError(string.Empty, "Empresa não encontrada.");
                return View();
            }

            return RedirectToAction("Details", new { id = empresa.Id });
        }

        // POST: Empresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeFantasia,RazaoSocial,CNPJ")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();

                // Redireciona para a página de detalhes da empresa recém-criada.
                return RedirectToAction("Details", new { id = empresa.Id });
            }
            return View(empresa);
        }


        // GET: Empresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST: Empresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeFantasia,RazaoSocial,CNPJ")] Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
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
            return View(empresa);
        }

        // GET: Empresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresa.Remove(empresa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.Id == id);
        }

        // GET: Empresa/DetailsProdutores/5
        public async Task<IActionResult> DetailsProdutores(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresa
                .FirstOrDefaultAsync(m => m.Id == id);  // Aqui você já está comparando corretamente o int? com o int
            if (empresa == null)
            {
                return NotFound();
            }

            var produtores = await _context.Produtor
                .Where(p => p.EmpresaId == id)  // Verifique se o EmpresaId de Produtor também é do tipo int?
                .ToListAsync();

            return View(produtores);  // Passa a lista de produtores para a view
        }

    }
}
