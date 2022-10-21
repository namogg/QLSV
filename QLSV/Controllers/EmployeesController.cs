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
                .Include(c => c.Certificates)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            
            if (employee == null)
            {
                return NotFound();
            }
            var fresher = await _context.Fresher
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if(fresher != null)
            {
                return View("Views/Freshers/Details.cshtml", fresher);
            }
            var intern = await _context.Intern
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (intern != null)
            {
                return View("Views/Interns/Details.cshtml", intern);
            }
            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (experience != null)
            {
                return View("Views/Experiences/Details.cshtml", experience);
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
            Fresher fresher = await _context.Fresher
                .Include(m => m.Employee)
                .Include(m => m.Employee.Certificates)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (fresher != null)
            {
                return View("Views/Freshers/Edit.cshtml", fresher);
            }
            Intern intern = await _context.Intern
                .Include(m => m.Employee)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (intern != null)
            {
                return View("Views/Interns/Edit.cshtml", intern);
            }
                Experience experience = await _context.Experience
                .Include(m => m.Employee)
                .Include(m => m.Employee.Certificates)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (experience != null)
            {
                    return View("Views/Experiences/Edit.cshtml", experience);
                }
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        // POST: Experiences/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExperience(Experience experience, List<Certificate> Certificates)
        {
            try
            {
                experience.Employee.Certificates = Certificates;
                _context.Update(experience);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        // POST: Experiences/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditIntern(Intern intern)
        {
            try
            {   
                _context.Update(intern);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        // POST: Experiences/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFresher(Fresher fresher, List<Certificate> Certificates)
        {
            try
            {
                fresher.Employee.Certificates = Certificates;
                _context.Update(fresher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
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
            Fresher fresher = await _context.Fresher
                .Include(m => m.Employee)
                .Include(m => m.Employee.Certificates)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (fresher != null)
            {
                return View("Views/Freshers/Delete.cshtml",fresher);
            }
            Intern intern = await _context.Intern
                .Include(m => m.Employee)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (intern != null)
            {
                return View("Views/Interns/Delete.cshtml",intern);
            }
            Experience experience = await _context.Experience
                .Include(m => m.Employee)
                .Include(m => m.Employee.Certificates)
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (experience != null)
            {
                return View("Views/Experiences/Delete.cshtml",experience);
            }
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
        // POST: /Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int EmployeeID)
        {
            if (_context.Experience == null)
            {
                return Problem("Entity set 'QLSVContext.Experience'  is null.");
            }
            var employee = await _context.Employee.FindAsync(EmployeeID);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Employees");
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
        // POST: ExperienceDTOController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExperience(ExperienceDTO experienceDTO)
        {
          Experience experience = new Experience(experienceDTO);
            if (ModelState.IsValid)
            {
                var e = experience.Employee;
                _context.Employee.Add(e);
                _context.SaveChanges();
                experience.EmployeeID = e.EmployeeId;
                var experiencedb = _context.Set<Experience>();
                experiencedb.Add(experience);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Employees");
        }
        // POST: ExperienceDTOController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateIntern(InternDTO internDTO)
        {
            Intern intern = new Intern(internDTO);
            {
                _context.Employee.Add(intern.Employee);
                _context.SaveChanges();
                intern.EmployeeID = intern.Employee.EmployeeId;
                var Interndb = _context.Set<Intern>();
                Interndb.Add(intern);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Employees");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFresher(FresherDTO fresherDTO)
        {
            Fresher fresher = new Fresher(fresherDTO);
            Employee employee = fresher.Employee;
            _context.Employee.Add(employee);
            _context.SaveChanges();
            fresher.EmployeeID = fresher.Employee.EmployeeId;
            _context.Fresher.Add(fresher);
            _context.SaveChanges();
            //save Certificate
             return RedirectToAction("Index");
        }
        //EmployeeType
        [HttpGet]
        public ActionResult Type()
        {
            return View("Views/ChooseType/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Type(string type)
        {
            if (type == "Fresher")
            {
                return View("Views/FresherDTO/Create.cshtml");
            }
            if (type == "Experience")
            {
                return View("Views/ExperienceDTO/Create.cshtml");
            }
            if (type == "Intern")
            {
                return View("Views/InternDTO/Create.cshtml");
            }
            return View();
        }
    }
}
