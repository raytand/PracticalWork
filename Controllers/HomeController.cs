using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PracticalWork.Controllers
{
    
    [Authorize]
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Contacts()
        {
            return View();
        }
    
    }
}
