using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiarioEmocional.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using DiarioEmocional.Data;

namespace DiarioEmocional.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _accessor;
        private ApplicationDbContext _context;

        public HomeController(UserManager<Usuario> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<Usuario> signInManager,
            ApplicationDbContext applicationDbContext,
            IHttpContextAccessor acessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = applicationDbContext;
            _accessor = acessor;
        }

        public async Task<Usuario> GetUser()
        {
            var user = await _userManager.GetUserAsync(_accessor.HttpContext.User);
            return user;
        }
        public IActionResult Index()
        {
            
            var user = GetUser().Result;
            if(user != null)
            {
                var RoleName = user.RoleName;
                if (RoleName=="Paciente")
                {
                    return RedirectToAction("Index", "Registroes");
                }
                else if(RoleName=="Psicoterapeuta"){
                    return RedirectToAction("UsuarioLogado", "Psicoterapeuta");
                }

            }


            return RedirectToAction("Login", "Paciente");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
