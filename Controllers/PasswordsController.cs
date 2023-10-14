using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalWork.DataAccess.Model;
using PracticalWork.DataAccess.Repositories;
namespace PracticalWork.Controllers
{
    [Authorize]
    public class PasswordsController : Controller
    {
        private IPasswordRepositories Repositories { get; }
        private readonly UserManager<User>? _userManager;
        public PasswordsController(UserManager<User>? userManager, IPasswordRepositories _Repositories)
        {
            Repositories = _Repositories;
            userManager = _userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? user = HttpContext.User.Identity?.Name;
            var result = await Repositories.GetPasswordAsync(user);
            return View(result);

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(PasswordsViewModel model)
        {
            if (ModelState.IsValid)
            {
                await Repositories.AddPasswordAsync(HttpContext.User.Identity?.Name, (UserPasswords)model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) { return NotFound(); }
            var user = await Repositories.FindPasswordByIdAsync(id.Value);
            if (user == null) { return NotFound(); }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await Repositories.DeletePasswordAsync(id);
            return Redirect("/Passwords/Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) { return NotFound(); }
            var user = await Repositories.FindPasswordByIdAsync(id.Value);
            if (id == null) { return NotFound(); }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PasswordsViewModel model)
        {
            if (id != model.PasswordId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    await Repositories.UpdatePasswordAsync(model);
                    return Redirect("/Passwords/Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await Repositories.PasswordExists(model.PasswordId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return View(model);
        }
    }
}
