using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Data;
using WebCourse.Models;

namespace WebCourse.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SkillsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Skills.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(Skill skills)
        {
            if (ModelState.IsValid)
            {
                _db.Add(skills);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skills);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}