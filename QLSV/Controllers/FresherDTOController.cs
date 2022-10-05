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
    public class FresherDTOController : Controller
    {
        private readonly QLSVContext _context;

        public FresherDTOController(QLSVContext context)
        {
            _context = context;
        }
        // GET: FresherDTOController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FresherDTOController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FresherDTOController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FresherDTOController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,room,gender,adress,Birth,Graduation_rank,Education,Graduation_date")] FresherDTO fresherDTO)
        {
            Fresher fresher = new Fresher(fresherDTO);
            if (!ModelState.IsValid)
            {
               return NotFound();
            }
            FreshersController FC = new FreshersController(_context);
            FC.AddFresher(fresherDTO);
            return RedirectToAction("Index", "Employees");
        }

        // GET: FresherDTOController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FresherDTOController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,room,gender,adress,Birth,Graduation_rank,Education,Graduation_date")] FresherDTO fresherDTO)
        {
            try
            {
                return RedirectToAction();
            }
            catch
            {
                return View();
            }
        }

        // GET: FresherDTOController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FresherDTOController/Delete/5
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
