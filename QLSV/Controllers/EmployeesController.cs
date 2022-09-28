using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLSV.Data;
using QLSV.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLSV.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly QLSVContext _context;

        public EmployeesController(QLSVContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string searchString)
        {
            var employee = from m in _context.Employee
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                employee = employee.Where(s => s.Name!.Contains(searchString));
            }

            return View(await employee.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            
            if (employee == null)
            {
                return NotFound();
            }
            var fresher = await _context.Fresher
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if(fresher != null)
            {
                FreshersController FC = new FreshersController(_context);
                FC.Details(id);
                return RedirectToAction("Details","Freshers", new { id = id });
            }
            var intern = await _context.Intern
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (intern != null)
            {
                InternsController FC = new InternsController(_context);
                FC.Details(id);
                return RedirectToAction("Details", "Interns", new { id = id });
            }
            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (experience != null)
            {
                ExperiencesController FC = new ExperiencesController(_context);
                FC.Details(id);
                return RedirectToAction("Details", "Experiences", new { id = id });
            }
            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {   
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,room,gender,adress,Birth")] Employee employee)
        {
            if (ModelState.IsValid)
            {   

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Employee.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("EmployeeId,Name,room,gender,adress,Birth")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();

            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employee == null)
            {
                return Problem("Entity set 'QLSVContext.Employee'  is null.");
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool EmployeeExists(int id)
        {
          return (_context.Employee?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
        public IActionResult Choose()
        {
            return RedirectToAction("Index","ChooseType");
        }
    }
}
