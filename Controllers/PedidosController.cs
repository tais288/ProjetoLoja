using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Models;
using ProjetoLoja.Repositories;

namespace ProjetoLoja.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoRepository _repository;

        public PedidosController(IPedidoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var pedidos = _repository.GetAll();
            return View(pedidos);
        }

        public IActionResult Details(int id)
        {
            var pedido = _repository.GetById(id);

            if (pedido == null)
                return NotFound();

            return View(pedido);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(pedido);
                return RedirectToAction(nameof(Index));
            }

            return View(pedido);
        }

        public IActionResult Edit(int id)
        {
            var pedido = _repository.GetById(id);

            if (pedido == null)
                return NotFound();

            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Pedido pedido)
        {
            if (id != pedido.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _repository.Update(pedido);
                return RedirectToAction(nameof(Index));
            }

            return View(pedido);
        }

        public IActionResult Delete(int id)
        {
            var pedido = _repository.GetById(id);

            if (pedido == null)
                return NotFound();

            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}