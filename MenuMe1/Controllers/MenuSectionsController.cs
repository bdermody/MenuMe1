using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MenuMe1.Data;
using MenuMe1.Models;

namespace MenuMe1.Controllers
{
    public class MenuSectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuSectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MenuSections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MenuSections.Include(m => m.Menu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MenuSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MenuSections == null)
            {
                return NotFound();
            }

            var menuSection = await _context.MenuSections
                .Include(m => m.Menu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuSection == null)
            {
                return NotFound();
            }

            return View(menuSection);
        }

        // GET: MenuSections/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id");
            return View();
        }

        // POST: MenuSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,MenuId,Position")] MenuSection menuSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menuSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", menuSection.MenuId);
            return View(menuSection);
        }

        // GET: MenuSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MenuSections == null)
            {
                return NotFound();
            }

            var menuSection = await _context.MenuSections.FindAsync(id);
            if (menuSection == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", menuSection.MenuId);
            return View(menuSection);
        }

        // POST: MenuSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,MenuId,Position")] MenuSection menuSection)
        {
            if (id != menuSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuSectionExists(menuSection.Id))
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
            ViewData["MenuId"] = new SelectList(_context.Menus, "Id", "Id", menuSection.MenuId);
            return View(menuSection);
        }

        // GET: MenuSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MenuSections == null)
            {
                return NotFound();
            }

            var menuSection = await _context.MenuSections
                .Include(m => m.Menu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuSection == null)
            {
                return NotFound();
            }

            return View(menuSection);
        }

        // POST: MenuSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MenuSections == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MenuSections'  is null.");
            }
            var menuSection = await _context.MenuSections.FindAsync(id);
            if (menuSection != null)
            {
                _context.MenuSections.Remove(menuSection);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuSectionExists(int id)
        {
          return (_context.MenuSections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
