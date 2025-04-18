using Gulnoza_Med.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gulnoza_Med.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        this._context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return BadRequest("Qidiruv so‘zi kiritilmagan!");

        var results = _context.Doctors
            .Where(p => p.Name.ToLower().Contains(query.ToLower()))
            .ToList();

        return Json(results);
    }

    public IActionResult HomePage()
    {
        var results = new Lists
        {
            Doctors = _context.Doctors.ToList(),
            Fields = _context.Fields.ToList()
        };
        return View(results);
    }

    public IActionResult FieldsPage()
    {
        var result = _context.Fields.ToList();
        return View(result);
    }

    public IActionResult DoctorsPage()
    {
        var result = _context.Doctors.ToList();
        return View(result);
    }

    public IActionResult TestimonialPage()
    {
        return View();
    }

    public IActionResult ContactUsPage()
    {
        return View();
    }

    public IActionResult DoctorDetailsPage(int id)
    {
        var result = _context.Doctors.ToList().FirstOrDefault(x => x.Id == id);
        return View(result);
    }
}

public class Lists
{
    public List<Doctors> Doctors { get; set; }
    public List<Fields> Fields { get; set; }
}