using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Data;
using Real_Estate.Models;

namespace Real_Estate.Controllers
{
   
    public class PropertiesController : Controller
    {
        private readonly RealEDbContext _context;

        public PropertiesController(RealEDbContext context)
        {
            _context = context;
        }


        // GET: Properties
        [Authorize(Roles = "Admin, Owner")]
        public async Task<IActionResult> Index(string SearchString)
        {
            //var realEstateDbContext = _context.Properties.Include(p => p.Propertytypes).Include(p => p.owner);
            //return View(await realEstateDbContext.ToListAsync());
            ViewData["CurrentFilter"] = SearchString;
            var property = from b in _context.EstateProperties
                           select b;
            if (!String.IsNullOrEmpty(SearchString))
            {
                property = property.Where(b => b.Name.Contains(SearchString) || b.Address.Contains(SearchString));
            }
            return View(await property.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> ZoomLink(string id)
        {
            ApplicationUser? user = await _context.ApplicationUsers.FindAsync(id);
            ViewBag.User = user;
            return View();
        }
       
        public async Task<IActionResult> Properties(string SearchString)
        {
           // var realEstateDbContext = _context.Properties.Include(p => p.Propertytypes).Include(p => p.owner);
            //return View(await realEstateDbContext.ToListAsync());

            ViewData["CurrentFilter"] = SearchString;
            var property = from b in _context.EstateProperties
                           select b;
            if (!String.IsNullOrEmpty(SearchString))
            {
                property = property.Where(b => b.Name.Contains(SearchString)|| b.Address.Contains(SearchString));
            }
            return View(await property.AsNoTracking().ToListAsync());
        }
        [Authorize(Roles = "Admin, Client, Owner")]

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstateProperties == null)
            {
                return NotFound();
            }

            var @property = await _context.EstateProperties
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }
        [Authorize(Roles = "Admin, Owner")]
        // GET: Properties/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin, Owner")]
        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Address,UrlImages,PriceifSale,PriceifRent,PropertytypesID,ownerID, MapLink")] EstateProperty property)
        {
            string Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ApplicationUser? user = await _context.ApplicationUsers.FindAsync(Id);
            if(user != null)
            {
                property.ApplicationUser = user;
            }
            if (ModelState.IsValid)
            {
                _context.Add(property);
                int value = await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }
        [Authorize(Roles = "Admin, Owner")]
        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstateProperties == null)
            {
                return NotFound();
            }

            var @property = await _context.EstateProperties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }
            return View(@property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Address,UrlImages,PriceifSale,PriceifRent,PropertytypesID,ownerID,MapLink")] EstateProperty @property)
        {
            if (id != @property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.Id))
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
            return View(@property);
        }
        [Authorize(Roles = "Admin, Owner")]
        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstateProperties == null)
            {
                return NotFound();
            }

            var @property = await _context.EstateProperties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstateProperties == null)
            {
                return Problem("Entity set 'RealEstateDbContext.Properties'  is null.");
            }
            var @property = await _context.EstateProperties.FindAsync(id);
            if (@property != null)
            {
                _context.EstateProperties.Remove(@property);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
          return (_context.EstateProperties?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
