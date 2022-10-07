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
    public class InternDTOController : Controller
    {
        private readonly QLSVContext _context;

        public InternDTOController(QLSVContext context)
        {
            _context = context;
        }
        // GET: InternDTOController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InternDTOController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InternDTOController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InternDTOController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InternDTO internDTO)
        {
            if (ModelState.IsValid)
            {
                InternsController IN = new InternsController(_context);
                IN.AddIntern(internDTO);
                return RedirectToAction("Index", "Employees");
            }
            return View();
        }

        // GET: InternDTOController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InternDTOController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InternDTOController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InternDTOController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
