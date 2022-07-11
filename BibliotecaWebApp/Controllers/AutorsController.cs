using BibliotecaWebApp.Data;
using BibliotecaWebApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace BibliotecaWebApp.Controllers
{
    public class AutorsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AutorsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Autor> objAutorList = _db.Autores;
            return View(objAutorList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Autor obj)
        {
            if (ModelState.IsValid)
            {
                _db.Autores.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Autor criado com sucesso";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var autorFromDb = _db.Autores.Find(id);
            // var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (autorFromDb == null)
            {
                return NotFound();
            }

            return View(autorFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Autor obj)
        {

            if (ModelState.IsValid)
            {
                _db.Autores.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Autor editado com sucesso";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var autorFromDb = _db.Autores.Find(id);
            // var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (autorFromDb == null)
            {
                return NotFound();
            }

            return View(autorFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Autores.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Autores.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Autor apagado com sucesso";
            return RedirectToAction("Index");


        }
    }
}
