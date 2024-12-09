using Internet1_RentACar.Models;
using Internet1_RentACar.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Internet1_RentACar.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository context)
        {
            _categoryRepository = context;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepository.GetAll().ToList();
            return View(objCategoryList); 
        }
        
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost] 
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                _categoryRepository.Save();
                TempData["basarili"] = "Başarıyla Eklendi";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepository.Get(u=>u.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                TempData["basarili"] = "Başarıyla Güncellendi";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) 
        {
            Category? category = _categoryRepository.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.Delete(category);
            _categoryRepository.Save();
            return RedirectToAction("Index");
        }


    }
}
