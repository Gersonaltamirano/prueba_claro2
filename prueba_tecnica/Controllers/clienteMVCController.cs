using Microsoft.AspNetCore.Mvc;

namespace prueba_tecnica.Controllers
{
    public class ClienteController : Controller
    {
        // Este método servirá la vista Razor
        public IActionResult Create()
        {
            return View();  // Esto buscará la vista "Create.cshtml" en "Views/Cliente/Create.cshtml"
        }
    }
}
