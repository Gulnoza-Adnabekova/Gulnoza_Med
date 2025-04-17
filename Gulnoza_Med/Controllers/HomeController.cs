﻿using Gulnoza_Med.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gulnoza_Med.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;
        public HomeController(AppDbContext db)
        {
            this.db = db;
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

            var results = db.Doctors
                .Where(p => p.Name.ToLower().Contains(query.ToLower()))
                .Select(d => d.Name)
                .ToList();

            return Json(results);
        }

        public IActionResult HomePage()
        {
            var results = new Lists
            {
                Doctors = db.Doctors.ToList(),
                Fields = db.Fields.ToList()
            };
            return View(results);
        }
        public IActionResult FieldsPage()
        {
            var result = db.Fields.ToList();
            return View(result);
        }
        public IActionResult DoctorsPage()
        {
            var result = db.Doctors.ToList();
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

        [HttpPost("api/contact")]
        public IActionResult SendContact([FromBody] ContactDto contact)
        {
            var user = new User()
            {
                FullName = contact.FullName,
                Email = contact.Email,
                Message = contact.Message,
                PhoneNumber = contact.PhoneNumber
            };

            db.Users.Add(user);
            db.SaveChanges();

            return Ok(new { message = "Xabar yuborildi" });
        }
        public IActionResult DoctorDetailsPage(int id)
        {
            var result = db.Doctors.ToList().FirstOrDefault(x => x.Id == id);
            return View(result);
        }
    }
    public class Lists
    {
        public List<Doctors> Doctors { get; set; }
        public List<Fields> Fields { get; set; }

    }
}
