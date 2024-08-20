using WebChat.Models;

namespace WebChat.Controllers
{
    public class RespostaChatControllers : Controllers
    {
        private readonly Contexto _context;

        public RespostaChatControllers(Contexto context)
        {
            _context = context;
        }
        //GET : RESPOSTACHATS

        public async Task<IActionResults> Index()
        {
            return View(await _context.RespostaChat.ToListAsync());
        }

        //GET : RESPOSTACHATS/details/S

        public async Task<IActionResults> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaChat = await _context.RespostaChat.FirstOrDefaultAsync(m => m.Id == id);
            
            if (respostaChat == null) { return NotFound(); }

            return View(respostaChat);
        }

        public IActionResult Create()
        {
            return View();
        }

        // [HttpPost]
        // [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Id,Resposta,Mensagem")] RespostaChat resposta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respostaChat);
                await _context.SaveChangesAsync();
                return RedirecToAction(nameof(Index));
            }
            return View(RespostaChat);
        }

        public Task<IActionResult> Edit(int? id)
        {
            if (id == null) { return NotFound(); }

            var respostaChat = await _context.RespostaChat.FirstOrDefaultAsync(m => m.Id == id);

            if (respostaChat == null) { return NotFound(); }

            return View(respostaChat);
        }

        public async Task<IActionResult> Edit(int id,[Bind("Id,Resposta,Mensagem")] RespostaChat resposta)
        {
            if(id != respostaChat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsIsValid)
            {
                try
                {
                    _context.Add(respostaChat);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    if (!RespostaChatExists(RespostaChat.Id))
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
            return View(respostaChat);
        }

        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var respostaChat = await _context.RespostaChat.FindAsync(id);
            _context.RespostaChat.Remove(respostaChat);
            await _context.SaveChangesAsync();
            return RedirectionToAction(nameof(Index));

        }

        private bool RespostaChatExists(int id)
        {
            return _context.RespostaChat.Any(x => x.Id == id);
        }
		// [HttpPost, ActionName("api/Chat")]
		
		public async Tasks<JsonResult> Chat(RequestApi request)
        {
            var respostaChat = await _context.RespostaChat.Where(m => m.mensagem.ToUpper().Conteins(request.mensagem.ToUpper())).FirstOrDefaultAsync();

            if (respostaChat != null)
            {
                var resposta = new ResponseApi { resposta = respostaChat.Resposta };
                return Json(resposta);
            }
            else
            {
                var resposta = new ResponseApi { resposta = "Não entendemos sua pergunta, pode reformular?" };
                return Json(resposta);
            }
        }
    }
}
