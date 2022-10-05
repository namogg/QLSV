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
    public class ExperiencesController : Controller
    {
        private readonly QLSVContext _context;

        public ExperiencesController(QLSVContext context)
        {
            _context = context;
        }

        // GET: Experiences
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Index", "Employees");
        }

        // GET: Experiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Experience == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            experience.Employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == experience.EmployeeID);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // GET: Experiences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Experiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpInYear,ProSkill,EmployeeId,Name,room,gender,adress,Birth")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experience);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExperience(ExperienceDTO experienceDTO)
        {
            Experience experience = new Experience(experienceDTO);
            if (ModelState.IsValid)
            {
                {
                    var employee = _context.Set<Employee>();
                    var e = experience.Employee;
                    employee.Add(e);
                    _context.SaveChanges();
                    experience.EmployeeID = e.EmployeeId;
                    var experiencedb = _context.Set<Experience>();
                    experiencedb.Add(experience);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(experience);
        }
        // GET: Experiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Experience == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience.FirstOrDefaultAsync(m => m.EmployeeID == id);
            experience.Employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (experience == null)
            {
                return NotFound();
            }
            return View(experience);
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Experience experience)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    experience.Employee.EmployeeId = experience.EmployeeID;
                    _context.Update(experience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceExists(experience.EmployeeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(experience);
        }

        // GET: Experiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Experience == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            experience.Employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == experience.EmployeeID);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Experience == null)
            {
                return Problem("Entity set 'QLSVContext.Experience'  is null.");
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceExists(int id)
        {
          return (_context.Experience?.Any(e => e.EmployeeID == id)).GetValueOrDefault();
        }
    }
}
