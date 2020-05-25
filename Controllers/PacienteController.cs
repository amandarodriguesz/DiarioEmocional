using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiarioEmocional.Data;
using DiarioEmocional.Models;
using DiarioEmocional.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiarioEmocional.Controllers
{
    public class PacienteController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ILogger<PsicoterapeutaController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _accessor;


        private ApplicationDbContext _context;


        public PacienteController(UserManager<Usuario> userManager,
            ILogger<PsicoterapeutaController> logger,
            RoleManager<IdentityRole> roleManager,
            SignInManager<Usuario> signInManager,
            ApplicationDbContext applicationDbContext,
            IHttpContextAccessor acessor
            )
        {
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = applicationDbContext;
            _accessor = acessor;
            //_usuarioID = usuarioId;
        }

        public IActionResult Index()
        {
            return View();
        }
       

        

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CadastrarPaciente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPost([FromForm]PacienteModelView pacienteModelView)
        {
            if (pacienteModelView != null)
            {
                if (!string.IsNullOrEmpty(pacienteModelView.Email)
                && !string.IsNullOrEmpty(pacienteModelView.Password)
                && !string.IsNullOrEmpty(pacienteModelView.RoleName))
                {
                    var psicoId = GetUser().Result.Id;
                    var user = new Usuario { UserName = pacienteModelView.UserName, Email = pacienteModelView.Email, RoleName = pacienteModelView.RoleName,PsicoterapeutaID= psicoId,NormalizedUserName=pacienteModelView.Name};
                    var result = await _userManager.CreateAsync(user, pacienteModelView.Password);

                    if (result.Succeeded)
                    {
                        bool roleExists = await _roleManager.RoleExistsAsync(pacienteModelView.RoleName);
                        if (!roleExists)
                        {
                            await _roleManager.CreateAsync(new IdentityRole(pacienteModelView.RoleName));
                            var permissao = await _userManager.AddToRoleAsync(user, "Paciente");
                            if (permissao.Succeeded)
                            {

                                _logger.LogInformation("Paciente criado.");
                                return Redirect("/Home/Index");
                            }
                        }
                        if (!await _userManager.IsInRoleAsync(user, pacienteModelView.RoleName))
                        {
                            await _userManager.AddToRoleAsync(user, pacienteModelView.RoleName);
                            return RedirectToAction("UsuarioLogado", "Psicoterapeuta");
                        }

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return RedirectToPage("/Psicoterapeuta/Register");

            }
            return RedirectToPage("/Psicoterapeuta/Register");
        }

        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> LoginPost(LoginView loginModel)
        {
            if (ModelState.IsValid)
            {

                var user = await _signInManager.UserManager.FindByNameAsync(loginModel.UserName);
                var roles = await _signInManager.UserManager.GetRolesAsync(user);

                var Paciente = roles.Where(x => x.Equals("Paciente")).Any();
                if (Paciente)
                {
                    var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);

                    if (result.Succeeded)
                        return RedirectToAction("Index", "Registroes");
                }

            }
            ModelState.AddModelError("", "Usuário não é paciente , solicite ao seu psicoterapeuta que realize o cadastro.");
            return RedirectToAction("Login", "Paciente");
        }
        public async Task<Usuario> GetUser()
        {
            var user = await _userManager.GetUserAsync(_accessor.HttpContext.User);
            return user;
        }

    }
}