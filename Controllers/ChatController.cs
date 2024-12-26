using Internet1_RentACar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Internet1_RentACar.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
