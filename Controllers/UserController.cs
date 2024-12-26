using Internet1_RentACar.Models;
using Internet1_RentACar.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Internet1_RentACar.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICategoryRepository _categoryRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;
        public readonly IUserRepository _userRepository;


        public UserController(ICarRepository carRepository, ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {

            List<ApplicationUser> objApplicationUserList = _userRepository.GetAll().ToList();


            return View(objApplicationUserList);

        }
    }
}
        /*
        public IActionResult Add(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _categoryRepository.GetAll()
               .Select(k => new SelectListItem
               {
                   Text = k.Name,
                   Value = k.Id.ToString()
               });

            ViewBag.CategoryList = CategoryList;
            return View();
        }


        [HttpPost] 
        public IActionResult Add(Car car, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string carPath = Path.Combine(wwwRootPath, @"img");

                using (var fileStream = new FileStream(Path.Combine(carPath, file.FileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                car.PhotoUrl = @"\img\" + file.FileName;

                _carRepository.Add(car);
                _carRepository.Save();
                TempData["basarili"] = "Başarıyla Eklendi";
                return RedirectToAction("Index", "Car");
            }
            return View();
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            IEnumerable<SelectListItem> CategoryList = _categoryRepository.GetAll()
               .Select(k => new SelectListItem
               {
                   Text = k.Name,
                   Value = k.Id.ToString()
               });

            ViewBag.CategoryList = CategoryList;
            Car? car = _carRepository.Get(u=>u.Id==id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpPost]
        public IActionResult Update(Car car, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string carPath = Path.Combine(wwwRootPath, @"img");
                if (file != null) { 
                using (var fileStream = new FileStream(Path.Combine(carPath, file.FileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                car.PhotoUrl = @"\img\" + file.FileName;
                }


            _carRepository.Update(car);
                _carRepository.Save();
                TempData["basarili"] = "Başarıyla Güncellendi";
                return RedirectToAction("Index", "Car");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Car? car = _carRepository.Get(u => u.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) 
        {
            Car? car = _carRepository.Get(u => u.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            _carRepository.Delete(car);
            _carRepository.Save();
            return RedirectToAction("Index");
        }


    } 
}*/
