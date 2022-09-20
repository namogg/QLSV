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
    public class InternsController : Controller
    {
        private readonly QLSVContext _context;

        public InternsController(QLSVContext context)
        {
            _context = context;
        }

        // GET: Interns
        public async Task<IActionResult> Index()
        {
              return _context.Intern != null ? 
                          View(await _context.Intern.ToListAsync()) :
                          Problem("Entity set 'QLSVContext.Intern'  is null.");
        }

        // GET: Interns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Intern == null)
            {
                return NotFound();
            }

            var intern = await _context.Intern
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (intern == null)
            {
                return NotFound();
            }

            return View(intern);
        }

        // GET: Interns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Interns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Majors,Semester,University_name,EmployeeId,Name,room,gender,adress,Birth")] Intern intern)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intern);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(intern);
        }

        // GET: Interns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Intern == null)
            {
                return NotFound();
            }

            var intern = await _context.Intern.FindAsync(id);
            if (intern == null)
            {
                return NotFound();
            }
            return View(intern);
        }

        // POST: Interns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Majors,Semester,University_name,EmployeeId,Name,room,gender,adress,Birth")] Intern intern)
        {
            if (id != intern.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intern);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InternExists(intern.EmployeeID))
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
            return View(intern);
        }

        // GET: Interns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Intern == null)
            {
                return NotFound();
            }

            var intern = await _context.Intern
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (intern == null)
            {
                return NotFound();
            }

            return View(intern);
        }

        // POST: Interns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Intern == null)
            {
                return Problem("Entity set 'QLSVContext.Intern'  is null.");
            }
            var intern = await _context.Intern.FindAsync(id);
            if (intern != null)
            {
                _context.Intern.Remove(intern);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InternExists(int id)
        {
          return (_context.Intern?.Any(e => e.EmployeeID == id)).GetValueOrDefault();
        }
    }
}
