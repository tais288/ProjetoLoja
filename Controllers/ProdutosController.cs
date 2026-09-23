using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Models;
using ProjetoLoja.Repositories;

namespace ProjetoLoja.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _repository;

        public ProdutosController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        // GET: Produtos
        public IActionResult Index()
        {
            var produtos = _repository.GetAll();
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public IActionResult Details(int id)
        {
            var produto = _repository.GetById(id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(produto);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public IActionResult Edit(int id)
        {
            var produto = _repository.GetById(id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Produto produto)
        {
            if (id != produto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _repository.Update(produto);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);
        }

        // GET: Produtos/Delete/5
        public IActionResult Delete(int id)
        {
            var produto = _repository.GetById(id);

            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}