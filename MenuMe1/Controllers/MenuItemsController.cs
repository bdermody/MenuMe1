﻿using System;
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
    public class MenuItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MenuItems
        public async Task<IActionResult> Index()
        {
              return _context.MenuItems != null ? 
                          View(await _context.MenuItems.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MenuItems'  is null.");
        }

        // GET: MenuItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MenuItems == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // GET: MenuItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMenuItem cmi)
        {
            MenuItem mi = new MenuItem(cmi);
            if (ModelState.IsValid)
            {
                _context.Add(mi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mi);
        }

        // GET: MenuItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MenuItems == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return View(menuItem);
        }

        // POST: MenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateMenuItem cmi)
        {
            MenuItem menuItem = new MenuItem(cmi);
            menuItem.Id = id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menuItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuItemExists(menuItem.Id))
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
            return View(menuItem);
        }

        // GET: MenuItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MenuItems == null)
            {
                return NotFound();
            }

            var menuItem = await _context.MenuItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // POST: MenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MenuItems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MenuItems'  is null.");
            }
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuItemExists(int id)
        {
          return (_context.MenuItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> BySection(int id)
        {

            var menuitems = _context.MenuItems.Where(m => m.MenuSectionId == id).OrderBy(m => m.Position); 
            return View(await menuitems.ToListAsync());
        }
    }
}
