using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiarioEmocional.Data;
using DiarioEmocional.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace DiarioEmocional.Controllers
{
    [Authorize(Roles = "Psicoterapeuta")]
    public class EmocaosController : Controller
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<Usuario> _userManager;

        private readonly ApplicationDbContext _context;
        private readonly DateTime _dataAtual;
        private Usuario _usuarioLogado;
        
        public EmocaosController(ApplicationDbContext context,
                                UserManager<Usuario> userManager,
                                IHttpContextAccessor accessor)
        {
            _context = context;
            _dataAtual = DateTime.Now;
            _accessor = accessor;
            _userManager = userManager;
        }



        // GET: Emocaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emocoes.Where(x=>x.Ativo).ToListAsync());
        }

        // GET: Emocaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emocao = await _context.Emocoes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emocao == null)
            {
                return NotFound();
            }

            return View(emocao);
        }

        // GET: Emocaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emocaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao")] Emocao emocao)
        {
            _usuarioLogado = GetUser().Result;
            if (ModelState.IsValid)
            {
                emocao.UsuarioInclusao = _usuarioLogado.Id;
                emocao.UsuarioAlteracao = _usuarioLogado.Id;
                emocao.DataInclusao = _dataAtual;
                emocao.DataAlteracao = _dataAtual;
                emocao.Ativo = true;
                _context.Add(emocao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emocao);
        }

        // GET: Emocaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emocao = await _context.Emocoes.FindAsync(id);
            if (emocao == null)
            {
                return NotFound();
            }
            return View(emocao);
        }

        // POST: Emocaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Emocao emocao)
        {
            _usuarioLogado = GetUser().Result;
            if (id != emocao.ID)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    //emocao.UsuarioInclusao = EmocaoAnterior.UsuarioInclusao;
                    //emocao.DataInclusao = EmocaoAnterior.DataInclusao;
                    emocao.UsuarioAlteracao = _usuarioLogado.Id;
                    emocao.DataAlteracao = _dataAtual;
                    emocao.Ativo = true;
                    _context.Update(emocao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmocaoExists(emocao.ID))
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
            return View(emocao);
        }

        // GET: Emocaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emocao = await _context.Emocoes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emocao == null)
            {
                return NotFound();
            }

            return View(emocao);
        }

        // POST: Emocaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emocao = await _context.Emocoes.FindAsync(id);
            _context.Emocoes.Remove(emocao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<Usuario> GetUser()
        {
            var user = await _userManager.GetUserAsync(_accessor.HttpContext.User);
            return user;
        }

        private bool EmocaoExists(int id)
        {
            return _context.Emocoes.Any(e => e.ID == id);
        }
    }
}

