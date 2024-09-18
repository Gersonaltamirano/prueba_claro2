using Microsoft.AspNetCore.Mvc;
using prueba_tecnica.Data;
using prueba_tecnica.Models;

namespace prueba_tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<IActionResult> InsertarCliente([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Cliente insertado correctamente", cliente });
        }


        // GET: api/Clientes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound(new { message = "Cliente no encontrado" });
            }

            // Calcular la edad del cliente
            var edad = DateTime.Now.Year - cliente.FechaNacimiento.Year;
            if (DateTime.Now.DayOfYear < cliente.FechaNacimiento.DayOfYear)
            {
                edad--;
            }

            return Ok(new
            {
                cliente.Nombre,
                cliente.Apellido,
                Edad = edad
            });
        }
    }
}
