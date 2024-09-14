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
    public class TranscationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TranscationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transcation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.trans.Include(t => t.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        

        // GET: Transcation/Create
        public IActionResult Create()
        {
            PopulateCategories();
            ViewData["CategoryId"] = new SelectList(_context.cat, "CategoryId", "CategoryId");
            return View(new TranscationTable());
        }

        // POST: Transcation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TranscationId,CategoryId,Amount,Note,Date")] TranscationTable transcationTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transcationTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCategories();
            return View(transcationTable);
        }

        // GET: Transcation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            PopulateCategories();
            if (id == null)
            {
                return NotFound();
            }

            var transcationTable = await _context.trans.FindAsync(id);
            if (transcationTable == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.cat, "CategoryId", "CategoryId", transcationTable.CategoryId);
            return View(transcationTable);
        }

        // POST: Transcation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TranscationId,CategoryId,Amount,Note,Date")] TranscationTable transcationTable)
        {
            if (id != transcationTable.TranscationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transcationTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranscationTableExists(transcationTable.TranscationId))
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
            ViewData["CategoryId"] = new SelectList(_context.cat, "CategoryId", "CategoryId", transcationTable.CategoryId);
            return View(transcationTable);
        }

        

        // POST: Transcation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transcationTable = await _context.trans.FindAsync(id);
            if (transcationTable != null)
            {
                _context.trans.Remove(transcationTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public void PopulateCategories() {
            var CategoryCollection = _context.cat.ToList();
            CategoryTable DefaultCategory = new CategoryTable() { CategoryId = 0, Title = "Choose a Category" };
            CategoryCollection.Insert(0, DefaultCategory);
            ViewBag.Categories = CategoryCollection;

        }

        private bool TranscationTableExists(int id)
        {
            return _context.trans.Any(e => e.TranscationId == id);
        }
    }
}
