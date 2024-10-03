using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace prueba_tecnica.Controllers
{
    public class PalindromoController : Controller
    {
        // GET: Palindromo/Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: Palindromo/ContarPalindromos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContarPalindromos(string texto)
        {
            var palindromos = ObtenerPalindromos(texto);
            ViewBag.TextoOriginal = texto; 
            ViewBag.Palindromos = palindromos;
            return View("MostrarPalindromos");
        }

        private List<string> ObtenerPalindromos(string texto)
        {
            var palabras = Regex.Split(texto, @"\W+");
            var palindromos = new List<string>();

            foreach (var palabra in palabras)
            {
                if (!string.IsNullOrEmpty(palabra) && palabra.Length > 1 && EsPalindromo(palabra))
                {
                    palindromos.Add(palabra);
                }
            }

            return palindromos;
        }

        private bool EsPalindromo(string palabra)
        {
            var palabraReversa = new string(palabra.Reverse().ToArray());
            return palabra.Equals(palabraReversa, StringComparison.OrdinalIgnoreCase);
        }
    }
}
