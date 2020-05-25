using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiarioEmocional.Data;
using DiarioEmocional.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace DiarioEmocional.Controllers
{
    [Authorize(Roles = "Psicoterapeuta")]
    public class IntensidadeController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<Usuario> _userManager;
        private Usuario _usuarioLogado;
        private readonly DateTime _dataAtual;

        public IntensidadeController(ApplicationDbContext context,
                                     UserManager<Usuario> userManager,
                                     IHttpContextAccessor accessor
            )
        {
            _context = context;
            _accessor = accessor;
            _userManager = userManager;
            _dataAtual = DateTime.Now;
        }

        // GET: Intensidade
        public async Task<IActionResult> Index()
        {
            _usuarioLogado = GetUser().Result;
            return View(await _context.Intensidades.Where(x=>x.Ativo).ToListAsync());
        }

        // GET: Intensidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intensidade = await _context.Intensidades
                .FirstOrDefaultAsync(m => m.ID == id);
            if (intensidade == null)
            {
                return NotFound();
            }

            return View(intensidade);
        }

        // GET: Intensidade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Intensidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao")] Intensidade intensidade)
        {
            _usuarioLogado = GetUser().Result;
            if (ModelState.IsValid)
            {
                intensidade.Ativo = true;
                intensidade.UsuarioInclusao = _usuarioLogado.Id;
                intensidade.UsuarioAlteracao = _usuarioLogado.Id;
                intensidade.DataInclusao = _dataAtual;
                intensidade.DataAlteracao = _dataAtual;
                _context.Add(intensidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(intensidade);
        }

        // GET: Intensidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intensidade = await _context.Intensidades.FindAsync(id);
            if (intensidade == null)
            {
                return NotFound();
            }
            return View(intensidade);
        }

        // POST: Intensidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Intensidade intensidade)
        {
            _usuarioLogado = GetUser().Result;
            if (id != intensidade.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                intensidade.Ativo = true;
                intensidade.UsuarioAlteracao = _usuarioLogado.Id;
                intensidade.DataAlteracao = _dataAtual;
                _context.Update(intensidade);
                await _context.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            return View(intensidade);
        }

        // GET: Intensidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var intensidade = await _context.Intensidades
                .FirstOrDefaultAsync(m => m.ID == id);
            if (intensidade == null)
            {
                return NotFound();
            }

            return View(intensidade);
        }

        // POST: Intensidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var intensidade = await _context.Intensidades.FindAsync(id);
            intensidade.Ativo = false;
            try
            {
                _context.Intensidades.Update(intensidade);
                //_context.Intensidades.Remove(intensidade);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntensidadeExists(intensidade.ID))
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
        public async Task<Usuario> GetUser()
        {
            var user = await _userManager.GetUserAsync(_accessor.HttpContext.User);
            return user;
        }
        private bool IntensidadeExists(int id)
        {
            return _context.Intensidades.Any(e => e.ID == id);
        }
    }
}
