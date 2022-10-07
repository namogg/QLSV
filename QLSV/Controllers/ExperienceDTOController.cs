using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLSV.Data;
using QLSV.Models;
namespace QLSV.Controllers
{
    public class ExperienceDTOController : Controller
    {
        private readonly QLSVContext _context;

        public ExperienceDTOController(QLSVContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        // POST: ExperienceDTOController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExperienceDTO experienceDTO)
        {
//            if (ModelState.IsValid)
            {
                ExperiencesController EX = new ExperiencesController(_context);
                EX.AddExperience(experienceDTO);
                return RedirectToAction("Index", "Employees");
            }
            return View();
        }
    }
}
