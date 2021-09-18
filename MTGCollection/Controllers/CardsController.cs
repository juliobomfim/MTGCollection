using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTGCollection.Data;
using MTGCollection.Interfaces;
using MTGCollection.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCollection.Controllers
{
    public class CardsController : Controller
    {
        private readonly MyDbContext _context;
        private readonly ICardServices _cardServices;

        public CardsController(MyDbContext context, ICardServices cardServices)
        {
            _context = context;
            _cardServices = cardServices;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            return View(await PaginatedList<Card>.CreateAsync(_context.Cards, pageNumber, 7));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,ManaCost,Type,Description,Lore,Collection,Power,Toughness,Color,Loyalty,Side,Image")] Card card)
        {
            if (ModelState.IsValid)
            {
                card.Id = Guid.NewGuid();
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,ManaCost,Type,Description,Lore,Collection,Power,Toughness,Color,Loyalty,Side,Image")] Card card)
        {
            if (id != card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.Id))
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
            return View(card);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var card = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(Guid id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<JsonResult> GetCardInfo(string name)
        {
            var result = await _cardServices.BuscarCard(name);

            return Json(result);
        }

    }
}
