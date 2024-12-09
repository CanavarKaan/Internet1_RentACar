using Internet1_RentACar.Models;
using Internet1_RentACar.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Internet1_RentACar.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]

    public class RentingController : Controller
    {

        private readonly IRentingRepository _rentingRepository;
        private readonly ICarRepository _carRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;


        public RentingController(IRentingRepository rentingRepository, ICarRepository carRepository, IWebHostEnvironment webHostEnvironment)
        {
            _rentingRepository = rentingRepository;
            _carRepository = carRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Renting> objRentingList = _rentingRepository.GetAll(includeProps:"Car").ToList();


            return View(objRentingList); 
        }
        
        public IActionResult Add(int? id)
        {
            IEnumerable<SelectListItem> CarList = _carRepository.GetAll()
               .Select(k => new SelectListItem
               {
                   Text = k.Brand + " " + k.Model,
                   Value = k.Id.ToString()
               });

            ViewBag.CarList = CarList;
            return View();
        }


        [HttpPost] 
        public IActionResult Add(Renting renting)
        {
            if (ModelState.IsValid)
            {

                _rentingRepository.Add(renting);
                _rentingRepository.Save();
                TempData["basarili"] = "Başarıyla Eklendi";
                return RedirectToAction("Index", "Renting");
            }
            return View();
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            IEnumerable<SelectListItem> CarList = _carRepository.GetAll()
               .Select(k => new SelectListItem
               {
                   Text = k.Brand + " " + k.Model,
                   Value = k.Id.ToString()
               });

            ViewBag.CarList = CarList;
            Renting? renting = _rentingRepository.Get(u=>u.Id==id);
            if (renting == null)
            {
                return NotFound();
            }
            return View(renting);
        }
        [HttpPost]
        public IActionResult Update(Renting renting)
        {
            if (ModelState.IsValid)
            {
                


            _rentingRepository.Update(renting);
                _rentingRepository.Save();
                TempData["basarili"] = "Başarıyla Güncellendi";
                return RedirectToAction("Index", "Renting");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {

            IEnumerable<SelectListItem> CarList = _carRepository.GetAll()
               .Select(k => new SelectListItem
               {
                   Text = k.Brand + " " + k.Model,
                   Value = k.Id.ToString()
               });
            ViewBag.CarList = CarList;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Renting? renting = _rentingRepository.Get(u => u.Id == id);
            if (renting == null)
            {
                return NotFound();
            }
            return View(renting);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) 
        {
            Renting? renting = _rentingRepository.Get(u => u.Id == id);
            if (renting == null)
            {
                return NotFound();
            }
            _rentingRepository.Delete(renting);
            _rentingRepository.Save();
            return RedirectToAction("Index");
        }


    }
}
