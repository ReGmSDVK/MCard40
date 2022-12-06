using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCard40.Model.Entity;
using MCard40.Web.Data;
using MCard40.Data.Context;

namespace MCard40.Web.Controllers
{
	public class WeekController : Controller
	{
        private readonly MCard40DbContext _context;

        public WeekController(MCard40DbContext context)
        {
            _context = context;
        }

        // GET: Week
        public async Task<IActionResult> Index()
        {
            var mCard40DbContext = _context.Weeks.Include(w => w.Doctor);
            return View(await mCard40DbContext.ToListAsync());
        }

        // GET: Week/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Weeks == null)
            {
                return NotFound();
            }

            var week = await _context.Weeks
                .Include(w => w.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (week == null)
            {
                return NotFound();
            }

            return View(week);
        }

        // GET: Week/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Address_home");
            return View();
        }

        // POST: Week/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,DayWeeks")] Week week)
        {
            if (ModelState.IsValid)
            {
                _context.Add(week);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Address_home", week.DoctorId);
            return View(week);
        }

        // GET: Week/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Weeks == null)
            {
                return NotFound();
            }

            var week = await _context.Weeks.FindAsync(id);
            if (week == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Address_home", week.DoctorId);
            return View(week);
        }

        // POST: Week/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,DayWeeks")] Week week)
        {
            if (id != week.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(week);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeekExists(week.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Address_home", week.DoctorId);
            return View(week);
        }

        // GET: Week/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Weeks == null)
            {
                return NotFound();
            }

            var week = await _context.Weeks
                .Include(w => w.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (week == null)
		{
                return NotFound();
		}

            return View(week);
        }

        // POST: Week/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Weeks == null)
            {
                return Problem("Entity set 'MCard40WebContext.Week'  is null.");
            }
            var week = await _context.Weeks.FindAsync(id);
            if (week != null)
		{
                _context.Weeks.Remove(week);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
		}
		
        private bool WeekExists(int id)
        {
          return _context.Weeks.Any(e => e.Id == id);
        }
	}
}
