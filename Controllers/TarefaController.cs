using listaTarefas.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace listaTarefas.Controllers
{
    public class TarefaController : Controller
    {
        private readonly AppDbContext _context;

        public TarefaController(AppDbContext context)
        {
            _context = context;
        }

        // LOGIN
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string senha)
        {
            if (email == "admin@avanade.com" && senha == "123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email)
                };

                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuth", principal);
                return RedirectToAction("Painel");
            }

            ViewBag.Mensagem = "E-mail ou senha inválidos";
            return View();
        }

        // LOGOUT
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login");
        }

        // PAINEL
        [Authorize]
        public IActionResult Painel()
        {
            return View();
        }

        // HOME
        public async Task<IActionResult> Index()
        {
            var tarefas = await _context.Tarefas.ToListAsync();
            return View(tarefas);
        }

        // CRIAR
        [Authorize]
        public IActionResult Create()
{
    var tarefas = _context.Tarefas
        .Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.Titulo
        }).ToList();

    ViewBag.Tarefas = tarefas;
    return View();
}


        [HttpPost]
[Authorize]
public async Task<IActionResult> Create(Tarefa tarefa)
{
    if (ModelState.IsValid)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();

        TempData["MensagemSucesso"] = "Tarefa criada com sucesso!";
        return RedirectToAction("Index");
    }

    return View(tarefa);
}


        // LISTA DE TAREFAS
        [Authorize]
        public async Task<IActionResult> Lista()
        {
            var tarefas = await _context.Tarefas.ToListAsync();
            return View(tarefas);
        }

       [Authorize]
public IActionResult EditPage()
{
    // Carrega a lista de tarefas para o dropdown
    var tarefas = _context.Tarefas
        .Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.Titulo
        }).ToList();

    ViewBag.Tarefas = tarefas;

    // Cria um modelo vazio para iniciar a tela
    var tarefa = new Tarefa
    {
        Titulo = "",
        Descricao = "",
        DataCriacao = DateTime.Today,
        Status = StatusTarefa.Pendente
    };

    return View("Edit", tarefa); // View: Views/Tarefa/Edit.cshtml
}

        [HttpPost]
[Authorize]
public async Task<IActionResult> Edit(Tarefa tarefa)
{
    if (!ModelState.IsValid)
    {
        return View("Edit", tarefa);
    }

    _context.Tarefas.Update(tarefa);
    await _context.SaveChangesAsync();

    TempData["MensagemSucesso"] = "Tarefa atualizada com sucesso!";
    return RedirectToAction("Lista");
}



[Authorize]
public IActionResult Edit(int id)
{
    var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
    if (tarefa == null)
    {
        return NotFound();
    }

    // Reenvia a lista de tarefas para manter o dropdown visível
    ViewBag.Tarefas = _context.Tarefas
        .Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.Titulo
        }).ToList();

    return View("Edit", tarefa);
}



       [Authorize]
public IActionResult DeletePage()
{
    var tarefas = _context.Tarefas
        .Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.Titulo
        }).ToList();

    ViewBag.Tarefas = tarefas;

    // Modelo vazio para iniciar a tela
    var tarefa = new Tarefa
    {
        DataCriacao = DateTime.Today,
        Status = StatusTarefa.Pendente
    };

    return View("Delete", tarefa); // View: Views/Tarefa/Delete.cshtml
}
[Authorize]
public IActionResult Delete(int id)
{
    var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
    if (tarefa == null)
    {
        return NotFound();
    }

    ViewBag.Tarefas = _context.Tarefas
        .Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.Titulo
        }).ToList();

    return View("Delete", tarefa);
}
[HttpPost]
[Authorize]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var tarefa = await _context.Tarefas.FindAsync(id);
    if (tarefa != null)
    {
        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
        TempData["MensagemSucesso"] = "Tarefa excluída com sucesso!";
    }

    return RedirectToAction("Lista");
}


    }
}