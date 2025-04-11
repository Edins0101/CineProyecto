using Microsoft.AspNetCore.Mvc;

namespace CineProyecto.WebApi.Controllers
{
    public class SalaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
