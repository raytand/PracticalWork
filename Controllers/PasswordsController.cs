using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PracticalWork.DataAccess.Model;
using PracticalWork.DataAccess.Repositories;
namespace PracticalWork.Controllers
{
    [Authorize]
    public class PasswordsController : Controller
    {
        private IPasswordRepositories Repositories { get; }
        private readonly UserManager<User>? _userManager;
        public PasswordsController(UserManager<User>? userManager,IPasswordRepositories _Repositories)
        {
            Repositories = _Repositories;
            userManager = _userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? user = HttpContext.User.Identity?.Name;
            var tasks = await Repositories.GetUserTasksAsync(user);
            return View(tasks); 
           
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
                await Repositories.AddTaskAsync(HttpContext.User.Identity?.Name, (UserPasswords)model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
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

    }
}
