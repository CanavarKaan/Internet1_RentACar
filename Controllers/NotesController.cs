using Internet1_RentACar.Models;
using Microsoft.AspNetCore.Mvc;

public class NotesController : Controller
{
    private static List<string> Notes = new List<string>(); // Temporary in-memory notes list

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddNote(string note)
    {
        if (!string.IsNullOrEmpty(note))
        {
            Notes.Add(note);
            return Json(new { success = true, notes = Notes });
        }
        return Json(new { success = false });
    }

    [HttpGet]
    public IActionResult GetNotes()
    {
        return Json(Notes);
    }
}