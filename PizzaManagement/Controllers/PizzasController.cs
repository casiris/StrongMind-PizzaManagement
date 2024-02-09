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
    public class PizzasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PizzasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pizzas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pizzas.Include(p => p.Topping1).Include(p => p.Topping2).Include(p => p.Topping3);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pizzas/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            ViewData["Topping1Id"] = new SelectList(_context.Toppings, "Id", "ToppingName");
            ViewData["Topping2Id"] = new SelectList(_context.Toppings, "Id", "ToppingName");
            ViewData["Topping3Id"] = new SelectList(_context.Toppings, "Id", "ToppingName");

            if (id == 0)
            {
                return View(new Pizza());
            }
            else
            {
                return View(_context.Pizzas.Find(id));
            }
        }

        // POST: Pizzas/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,PizzaName,Topping1Id,Topping2Id,Topping3Id")] Pizza pizza)
        {
            // Check if a pizza with the same name already exists
            if (_context.Pizzas.Any(p =>
                p.PizzaName == pizza.PizzaName &&
                p.Id != pizza.Id))
            {
                ModelState.AddModelError("PizzaName", "A pizza with this name already exists.");
            }

            if (_context.Pizzas.Any(p => p.Topping1Id == pizza.Topping1Id
                && p.Topping2Id == pizza.Topping2Id
                && p.Topping3Id == pizza.Topping3Id))
            {
                ModelState.AddModelError("PizzaName", "A pizza with those toppings already exists.");
            }

            if (ModelState.IsValid)
            {
                if (pizza.Id == 0)
                {
                    _context.Add(pizza);
                    
                }
                else
                {
                    _context.Update(pizza);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Topping1Id"] = new SelectList(_context.Toppings, "Id", "ToppingName", pizza.Topping1Id);
            ViewData["Topping2Id"] = new SelectList(_context.Toppings, "Id", "ToppingName", pizza.Topping2Id);
            ViewData["Topping3Id"] = new SelectList(_context.Toppings, "Id", "ToppingName", pizza.Topping3Id);

            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaExists(int id)
        {
            return _context.Pizzas.Any(e => e.Id == id);
        }
    }
}
