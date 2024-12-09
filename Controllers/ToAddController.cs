using Internet1_RentACar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Internet1_RentACar.Controllers
{
    public class ToAddController : Controller
    {
        // Geçici olarak arabaları depolamak için
        private static List<ToAdd> _carList = new();

        // Listeyi Görüntülemek için Ana Sayfa
        public IActionResult Index()
        {
            return View(_carList);
        }

        // AJAX ile Listeye Ekleme
        [HttpPost]
        public IActionResult AddToList(ToAdd car)
        {
            if (ModelState.IsValid)
            {
                _carList.Add(car);
                return Json(new { success = true, message = "Araba listeye eklendi!", data = _carList });
            }
            return Json(new { success = false, message = "Geçersiz veri." });
        }
    }
}
