using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaManagement.Data;
using PizzaManagement.Models;

namespace PizzaManagement.Controllers
{
    public class ToppingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToppingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Toppings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Toppings.ToListAsync());
        }

        // GET: Toppings/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new Topping());
            }
            else 
            { 
                return View(_context.Toppings.Find(id));
            }
        }

        // POST: Toppings/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,ToppingName")] Topping topping)
        {
            if (ModelState.IsValid)
            {
                if (topping.Id == 0)
                {
                    _context.Add(topping);
                }
                else
                {
                    _context.Update(topping);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topping);
        }

        // POST: Toppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toppingToDelete = await _context.Toppings.FindAsync(id);

            if (toppingToDelete == null)
            {
                return NotFound();
            }

            var pizzasWithTopping = _context.Pizzas
                .Where(p => p.Topping1Id == id || p.Topping2Id == id || p.Topping3Id == id)
                .ToList();

            if (pizzasWithTopping.Any())
            {
                TempData["ErrorMessage"] = "A pizza exists with that topping. You cannot delete it.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _context.Toppings.Remove(toppingToDelete);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Topping deleted successfully.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
