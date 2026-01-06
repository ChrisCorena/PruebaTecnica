using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TiendaOnline.Data;
using TiendaOnline.Models;

namespace TiendaOnline.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoRepository _repository;

        public ProductosController(ProductoRepository repository)
        {
            _repository = repository;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var productos = await _repository.ObtenerProductosAsync();
            return View(productos);
        }

        // GET: Productos/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Productos/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            await _repository.InsertarProductoAsync(producto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Productos/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var producto = await _repository.ObtenerProductoPorIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }


        // POST: Productos/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            await _repository.ActualizarProductoAsync(producto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Productos/Eliminar/5
        public async Task<IActionResult> Eliminar(int id)
        {
            var producto = await _repository.ObtenerProductoPorIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _repository.EliminarProductoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
