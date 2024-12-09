using Internet1_RentACar.Models;
using Internet1_RentACar.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Internet1_RentACar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository _carRepository;
        private readonly ICategoryRepository _categoryRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ICarRepository carRepository, ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _carRepository = carRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Car> objCarList = _carRepository.GetAll(includeProps: "Category").ToList();
            return View(objCarList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
