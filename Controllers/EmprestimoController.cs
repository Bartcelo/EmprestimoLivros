using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emprestimo.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private AppDbContext _db;

        public EmprestimoController(AppDbContext db)
        {
            _db = db;


        }
        public IActionResult Index()
        {

            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;

            return View(emprestimos);
        }


        public IActionResult Cadastro() {

            return View();

        }

        [HttpPost]
        public IActionResult Cadastro(EmprestimosModel emprestimos)
        {

            if (ModelState.IsValid)
            {
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return RedirectToAction("Update");

        }

        [HttpGet]
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();

            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(e => e.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);


        }
        [HttpPost]
        public IActionResult Update(EmprestimosModel emprestimo)
        {

            if (ModelState.IsValid) {

                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(emprestimo);



        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();

            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(e => e.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }




        [HttpPost]
        public IActionResult Delete(EmprestimosModel emprestimo)
        {

            if (emprestimo == null )
            {
                return NotFound();
               
            }
                _db.Emprestimos.Remove(emprestimo);
                _db.SaveChanges();

                
            
           return RedirectToAction("Index");
        }


    }
}
