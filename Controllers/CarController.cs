using Internet1_RentACar.Models;
using Internet1_RentACar.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Internet1_RentACar.Hubs;
using SignalR_CarCount.Hubs;
using Microsoft.EntityFrameworkCore;

namespace Internet1_RentACar.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHubContext<CarHub> _hubContext;

        public CarController(
            ICarRepository carRepository,
            ICategoryRepository categoryRepository,
            IWebHostEnvironment webHostEnvironment,
            IHubContext<CarHub> hubContext)
        {
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            var carList = _carRepository.GetAll(includeProps: "Category").ToList();
            return View(carList);
        }

        public IActionResult Add()
        {
            ViewBag.CategoryList = _categoryRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Name,
                    Value = k.Id.ToString()
                });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Car car, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string carPath = Path.Combine(wwwRootPath, "img");

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string fullPath = Path.Combine(carPath, fileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    car.PhotoUrl = $"/img/{fileName}";
                }

                _carRepository.Add(car);
                _carRepository.Save();

                // SignalR ile araba sayısını güncelle
                var carCount = _carRepository.GetAll().Count();
                await _hubContext.Clients.All.SendAsync("ReceiveCarCount", carCount);

                TempData["basarili"] = "Başarıyla Eklendi";
                return RedirectToAction("Index");
            }

            ViewBag.CategoryList = _categoryRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Name,
                    Value = k.Id.ToString()
                });

            return View(car);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carRepository.Get(u => u.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            ViewBag.CategoryList = _categoryRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Name,
                    Value = k.Id.ToString()
                });

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Car car, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string carPath = Path.Combine(wwwRootPath, "img");

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string fullPath = Path.Combine(carPath, fileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    car.PhotoUrl = $"/img/{fileName}";
                }

                _carRepository.Update(car);
                _carRepository.Save();

                TempData["basarili"] = "Başarıyla Güncellendi";
                return RedirectToAction("Index");
            }

            ViewBag.CategoryList = _categoryRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Name,
                    Value = k.Id.ToString()
                });

            return View(car);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carRepository.Get(u => u.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _carRepository.Get(u => u.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            _carRepository.Delete(car);
            _carRepository.Save();

            // SignalR ile araba sayısını güncelle
            var carCount = _carRepository.GetAll().Count();
            await _hubContext.Clients.All.SendAsync("ReceiveCarCount", carCount);

            return RedirectToAction("Index");
        }
    }
}