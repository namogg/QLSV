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
            return RedirectToAction("Index", "Employees");
        }

        // GET: Freshers/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fresher == null)
            {
                return NotFound();
            }

            var fresher = await _context.Fresher
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            fresher.Employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == fresher.EmployeeID);
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
        public async Task<IActionResult> Create([Bind("Graduation_rank,Education,Graduation_date,EmployeeId,Name,room,gender,adress,Birth")] Fresher fresher)
        {
            //Fresher fresher = new Fresher(fresherDTO);
            if (ModelState.IsValid)
            {
                _context.Add(fresher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fresher);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFresher(FresherDTO fresherDTO)
        {
            Fresher fresher = new Fresher(fresherDTO);
            if (ModelState.IsValid)
            {
                {
                    Employee employee = fresher.Employee;
                    _context.Employee.Add(employee);
                    _context.SaveChanges();
                    fresher.EmployeeID = fresher.Employee.EmployeeId;
                    _context.Fresher.Add(fresher);
                    _context.SaveChanges();
                    //save Certificate
                    var certificates = fresher.Employee.Certificates;
                    foreach (var _Certificate in certificates)
                    {
                        _Certificate.EmployeeID = fresher.Employee.EmployeeId;
                        _Certificate.Employee = fresher.Employee;
                        _context.Certificate.Add(_Certificate);
                        _context.SaveChanges();
                    }
                    return RedirectToAction(nameof(Index));
                }

                //save Fresher
                
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

            var fresher = await _context.Fresher.FirstOrDefaultAsync(m => m.EmployeeID == id);
            fresher.Employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
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
        public async Task<IActionResult> Edit(Fresher fresher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    fresher.Employee.EmployeeId = fresher.EmployeeID;
                    _context.Update(fresher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FresherExists(fresher.EmployeeID))
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
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            fresher.Employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == fresher.EmployeeID);
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
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee); 
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Employee");
        }

        private bool FresherExists(int id)
        {
          return (_context.Fresher?.Any(e => e.EmployeeID == id)).GetValueOrDefault();
        }
    }
}
