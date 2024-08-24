using Microsoft.AspNetCore.Mvc;
using Practice_One.Data;
using Practice_One.Models;

namespace Practice_One.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display order and name can not be the same");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is not a valid value");
            }
            if (ModelState.IsValid) {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Has Been Added Successfully";
             return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id  == 0 || id == null)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            if ( categoryFromDb == null)
            {
                return NotFound();
            }
                return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Has Been Edited Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Has Been Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
