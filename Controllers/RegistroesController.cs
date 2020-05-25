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
    [Authorize(Roles = "Paciente")]
    public class RegistroesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<Usuario> _userManager;
        private Usuario _usuarioLogado;
        private readonly DateTime _dataAtual;
        public RegistroesController(UserManager<Usuario> userManager,
                                    ApplicationDbContext context,
                                    IHttpContextAccessor accessor
                                   )
        {
            _context = context;
            _accessor = accessor;
            _userManager = userManager;
            _dataAtual = DateTime.Now;
        }

        // GET: Registroes
        public async Task<IActionResult> Index()
        {
            _usuarioLogado = GetUser().Result;
            var applicationDbContext = _context.Registros
                                        .Include(r => r.Emocao)
                                        .Include(r => r.Intensidade)
                                        .Where(x=>x.UsuarioInclusao == _usuarioLogado.Id && x.Ativo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Registroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Emocao)
                .Include(r => r.Intensidade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registroes/Create
        public IActionResult Create()
        {
            ViewData["EmocaoID"] = new SelectList(_context.Emocoes, "ID", "Descricao");
            ViewData["IntensidadeID"] = new SelectList(_context.Intensidades, "ID", "Descricao");
            return View();
        }

        // POST: Registroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Registro registro)
        {
            _usuarioLogado = GetUser().Result;
            if (ModelState.IsValid)
            {
                registro.Ativo = true;
                registro.UsuarioInclusao = _usuarioLogado.Id;
                registro.UsuarioAlteracao = _usuarioLogado.Id;
                registro.DataInclusao = _dataAtual;
                registro.DataAlteracao = _dataAtual;
                _context.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmocaoID"] = new SelectList(_context.Emocoes, "ID", "Descricao", registro.EmocaoID);
            ViewData["IntensidadeID"] = new SelectList(_context.Intensidades, "ID", "Descricao",registro.IntensidadeID);
            return View(registro);
        }

        // GET: Registroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            ViewData["EmocaoID"] = new SelectList(_context.Emocoes, "ID", "Descricao", registro.EmocaoID);
            ViewData["IntensidadeID"] = new SelectList(_context.Intensidades, "ID", "Descricao", registro.IntensidadeID);
            return View(registro);
        }

        // POST: Registroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Registro registro)
        {
            _usuarioLogado = GetUser().Result;
            if (id != registro.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                registro.UsuarioAlteracao = _usuarioLogado.Id;
                registro.DataAlteracao = _dataAtual;
                try
                {
                    _context.Update(registro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroExists(registro.ID))
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
            ViewData["EmocaoID"] = new SelectList(_context.Emocoes, "ID", "Descricao", registro.EmocaoID);
            ViewData["IntensidadeID"] = new SelectList(_context.Intensidades, "ID", "Descricao", registro.IntensidadeID);
            return View(registro);
        }

        
        public async Task<IActionResult> MandarParaPsicoterapeuta(int? id)
        {
            _usuarioLogado = GetUser().Result;
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }

            registro.UsuarioAlteracao = _usuarioLogado.Id;
            registro.DataAlteracao = _dataAtual;
            try
            {
                registro.EnviarPsicoterapeuta = true;
                _context.Update(registro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroExists(registro.ID))
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


        // GET: Registroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Emocao)
                .Include(r=>r.Intensidade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _usuarioLogado = GetUser().Result;
            var registro = await _context.Registros.FindAsync(id);
            registro.DataAlteracao = _dataAtual;
            registro.UsuarioAlteracao = _usuarioLogado.Id;
            registro.Ativo = false;
            _context.Update(registro);
            //_context.Registros.Remove(registro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
            return _context.Registros.Any(e => e.ID == id);
        }

        public async Task<Usuario> GetUser()
        {
            var user = await _userManager.GetUserAsync(_accessor.HttpContext.User);
            return user;
        }
    }
}
