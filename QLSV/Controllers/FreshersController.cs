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
    public class FreshersController : Controller
    {
        private readonly QLSVContext _context;

        public FreshersController(QLSVContext context)
        {
            _context = context;
        }

        // GET: Freshers
        public async Task<IActionResult> Index()
        {
              return _context.Fresher != null ? 
                          View(await _context.Fresher.ToListAsync()) :
                          Problem("Entity set 'QLSVContext.Fresher'  is null.");
        }

        // GET: Freshers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fresher == null)
            {
                return NotFound();
            }

            var fresher = await _context.Fresher
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (fresher == null)
            {
                return NotFound();
            }

            return View(fresher);
        }

        // GET: Freshers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Freshers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FresherID,Graduation_rank,Education,Graduation_date,EmployeeId,Name,room,gender,adress,Birth")] Fresher fresher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fresher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fresher);
        }

        // GET: Freshers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fresher == null)
            {
                return NotFound();
            }

            var fresher = await _context.Fresher.FindAsync(id);
            if (fresher == null)
            {
                return NotFound();
            }
            return View(fresher);
        }

        // POST: Freshers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FresherID,Graduation_rank,Education,Graduation_date,EmployeeId,Name,room,gender,adress,Birth")] Fresher fresher)
        {
            if (id != fresher.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fresher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FresherExists(fresher.EmployeeId))
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
            return View(fresher);
        }

        // GET: Freshers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fresher == null)
            {
                return NotFound();
            }

            var fresher = await _context.Fresher
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (fresher == null)
            {
                return NotFound();
            }

            return View(fresher);
        }

        // POST: Freshers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fresher == null)
            {
                return Problem("Entity set 'QLSVContext.Fresher'  is null.");
            }
            var fresher = await _context.Fresher.FindAsync(id);
            if (fresher != null)
            {
                _context.Fresher.Remove(fresher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FresherExists(int id)
        {
          return (_context.Fresher?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
