﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLSV.Data;
using QLSV.Models;
using PagedList;
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
        public async Task<IActionResult> Index(string sortOrder, string searchString, int? pageNumber, string currentFilter)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentSort"] = sortOrder;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var employee = from m in _context.Employee
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                employee = employee.Where(s => s.Name!.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(sortOrder))
            {
                employee = employee.OrderByDescending(s => s.Name);
            }
            int pageSize = 5;
            return View(await PaginatedList<Employee>.CreateAsync(employee.AsNoTracking(), pageNumber ?? 1, pageSize));
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

            var employee = await _context.Employee.FindAsync(id);
            var fresher = await _context.Fresher
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (fresher != null)
            {
                FreshersController FC = new FreshersController(_context);
                FC.Edit(id);
                return RedirectToAction("Edit", "Freshers", new { id = id });
            }
            var intern = await _context.Intern
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (intern != null)
            {
                InternsController FC = new InternsController(_context);
                FC.Edit(id);
                return RedirectToAction("Edit", "Interns", new { id = id });
            }
            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (experience != null)
            {
                ExperiencesController FC = new ExperiencesController(_context);
                FC.Edit(id);
                return RedirectToAction("Edit", "Experiences", new { id = id });
            }
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
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
            var fresher = await _context.Fresher
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (fresher != null)
            {
                FreshersController FC = new FreshersController(_context);
                FC.Delete(id);
                return RedirectToAction("Delete", "Freshers", new { id = id });
            }
            var intern = await _context.Intern
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (intern != null)
            {
                InternsController FC = new InternsController(_context);
                FC.Delete(id);
                return RedirectToAction("Delete", "Interns", new { id = id });
            }
            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (experience != null)
            {
                ExperiencesController FC = new ExperiencesController(_context);
                FC.Delete(id);
                return RedirectToAction("Delete", "Experiences", new { id = id });
            }
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCertificates(Employee employee,int id)
        {
            var employeeID = id;
            var certificates = employee.Certificates;
            foreach(var C in certificates)
            {
                var certificate = new Certificate
                {
                    EmployeeID = employeeID,
                    CertificateName = C.CertificateName,
                    CertificateRank = C.CertificateRank,
                    GraduationDate = C.GraduationDate
                };
                await _context.AddAsync(certificate);
                await _context.SaveChangesAsync();
            }
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
