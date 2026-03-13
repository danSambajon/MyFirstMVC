using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstMVC.Data;
using MyFirstMVC.Models;

namespace MyFirstMVC.Controllers
{
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CardsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Cards.ToListAsync());
        }

        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cards = await _dbContext.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cards == null)
            {
                return NotFound();
            }

            return View(cards);
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] Cards cards)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(cards);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cards);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cards = await _dbContext.Cards.FindAsync(id);
            if (cards == null)
            {
                return NotFound();
            }
            return View(cards);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] Cards cards)
        {
            if (id != cards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(cards);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardsExists(cards.Id))
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
            return View(cards);
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cards = await _dbContext.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cards == null)
            {
                return NotFound();
            }

            return View(cards);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cards = await _dbContext.Cards.FindAsync(id);
            if (cards != null)
            {
                _dbContext.Cards.Remove(cards);
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardsExists(int id)
        {
            return _dbContext.Cards.Any(e => e.Id == id);
        }
    }
}
