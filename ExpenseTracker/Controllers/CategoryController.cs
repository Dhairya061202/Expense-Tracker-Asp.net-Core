using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;

namespace ExpenseTracker.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.cat.ToListAsync());
        }

        //// GET: Category/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var categoryTable = await _context.cat
        //        .FirstOrDefaultAsync(m => m.CategoryId == id);
        //    if (categoryTable == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(categoryTable);
        //}

        // GET: Category/Create
        public IActionResult Create()
        {
            
            return View(new CategoryTable());
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Title,Icon,Type")] CategoryTable categoryTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryTable);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryTable = await _context.cat.FindAsync(id);
            if (categoryTable == null)
            {
                return NotFound();
            }
            return View(categoryTable);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Title,Icon,Type")] CategoryTable categoryTable)
        {
            if (id != categoryTable.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryTableExists(categoryTable.CategoryId))
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
            return View(categoryTable);
        }

        // GET: Category/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var categoryTable = await _context.cat
        //        .FirstOrDefaultAsync(m => m.CategoryId == id);
        //    if (categoryTable == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(categoryTable);
        //}

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryTable = await _context.cat.FindAsync(id);
            if (categoryTable != null)
            {
                _context.cat.Remove(categoryTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryTableExists(int id)
        {
            return _context.cat.Any(e => e.CategoryId == id);
        }
    }
}
