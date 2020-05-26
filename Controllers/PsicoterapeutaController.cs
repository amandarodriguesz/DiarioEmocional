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
    public class PsicoterapeutaController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly ILogger<PsicoterapeutaController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _accessor;

        private ApplicationDbContext _context;


        public PsicoterapeutaController(UserManager<Usuario> userManager,
            ILogger<PsicoterapeutaController> logger,
            RoleManager<IdentityRole> roleManager,
            SignInManager<Usuario> signInManager,
            ApplicationDbContext applicationDbContext,
            IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = applicationDbContext;
            _accessor = accessor;
        }

        public IActionResult Index()
        {
            return View("UsuarioLogado");
        }

        [HttpGet,ActionName("UsuarioLogado")]
        public IActionResult UsuarioLogado()
        {
            var psicoId = GetUser().Result.Id;
            var pacientes = GetPacientes(psicoId);
            return View(pacientes);
        }

        public ICollection<Usuario> GetPacientes(string id)
        {
           if(!string.IsNullOrEmpty(id))
            {
                var pacientes = _context.Usuarios.Where(x=> x.PsicoterapeutaID == id).ToList();
                return pacientes;
            }
            return null;
        }

        public IActionResult VisualizarRegistrosPaciente(string id)
        {
            var psicoId = GetUser().Result.Id;
            if (!string.IsNullOrEmpty(id))
            {
                var registros = _context.Registros
                                .Where(x => x.UsuarioInclusao == id
                                        && x.EnviarPsicoterapeuta //lista somente registros que o paciente enviou
                                        && x.Ativo).ToList();
                
                
                return View(registros);
            }
            return null;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> LoginPost(LoginView loginModel)
        {
            if (ModelState.IsValid)
            {

                var user = await _signInManager.UserManager.FindByNameAsync(loginModel.UserName);
                var roles = await _signInManager.UserManager.GetRolesAsync(user);

                var Psicoterapeuta = roles.Where(x => x.Equals("Psicoterapeuta")).Any();
                if (Psicoterapeuta)
                {
                    var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);

                    if (result.Succeeded)
                        return RedirectToAction("UsuarioLogado", "Psicoterapeuta");
                }

            }
            ModelState.AddModelError("", "Usuário não é psicoterapeuta , tente logar como paciente.");
            return RedirectToAction("Login", "Paciente");
        }
        [HttpPost]
        public async Task<IActionResult> RegisterPost([FromForm]PsicoterapeutaModelView psicoterapeutaModelView)
        {
            if (psicoterapeutaModelView != null)
            {
                if (!string.IsNullOrEmpty(psicoterapeutaModelView.Email)
                && !string.IsNullOrEmpty(psicoterapeutaModelView.Password)
                && !string.IsNullOrEmpty(psicoterapeutaModelView.RoleName))
                {
                    var user = new Usuario { UserName = psicoterapeutaModelView.UserName, Email = psicoterapeutaModelView.Email, RoleName = psicoterapeutaModelView.RoleName };
                    var result = await _userManager.CreateAsync(user, psicoterapeutaModelView.Password);

                    if (result.Succeeded)
                    {
                        bool roleExists = await _roleManager.RoleExistsAsync(psicoterapeutaModelView.RoleName);
                        if (!roleExists)
                        {
                            await _roleManager.CreateAsync(new IdentityRole(psicoterapeutaModelView.RoleName));
                            var permissao = await _userManager.AddToRoleAsync(user, "Psicoterapeuta");
                            if (permissao.Succeeded)
                            {

                                _logger.LogInformation("Psicoterapeuta cadastrado com sucesso.");
                                return Redirect("/Psicoterapeuta/Index");
                            }
                        }
                        if (!await _userManager.IsInRoleAsync(user, psicoterapeutaModelView.RoleName))
                        {
                            await _userManager.AddToRoleAsync(user, psicoterapeutaModelView.RoleName);
                            return RedirectToAction("Index", "Psicoterapeuta");
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

        public async Task<Usuario> GetUser()
        {
            var user = await _userManager.GetUserAsync(_accessor.HttpContext.User);
            return user;
        }

    }


    }
