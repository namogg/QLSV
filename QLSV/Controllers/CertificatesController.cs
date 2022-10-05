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
    public class CertificatesController : Controller
    {
        private readonly QLSVContext _context;

        public CertificatesController(QLSVContext context)
        {
            _context = context;
        }

        // GET: Certificates
        public async Task<IActionResult> Index(int? id)
        {
            var certificates = from m in _context.Certificate
                           select m;
            if (id != null)
            {
                certificates = certificates.Where(s => s.EmployeeID == id);
            }
            
            return View(await certificates.ToListAsync());
        }

        // GET: Certificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Certificate == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificate
                .FirstOrDefaultAsync(m => m.CertificateID == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // GET: Certificates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Certificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certificate);
        }

        // GET: Certificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Certificate == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificate.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }
            return View(certificate);
        }

        // POST: Certificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CertificateID,CertificateName,CertificateRank,GraduationDate")] Certificate certificate)
        {
            if (id != certificate.CertificateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificateExists(certificate.CertificateID))
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
            return View(certificate);
        }

        // GET: Certificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Certificate == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificate
                .FirstOrDefaultAsync(m => m.CertificateID == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // POST: Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Certificate == null)
            {
                return Problem("Entity set 'QLSVContext.Certificate'  is null.");
            }
            var certificate = await _context.Certificate.FindAsync(id);
            if (certificate != null)
            {
                _context.Certificate.Remove(certificate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CertificateExists(int id)
        {
          return (_context.Certificate?.Any(e => e.CertificateID == id)).GetValueOrDefault();
        }
    }
}
