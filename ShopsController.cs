using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ShopsController : Controller
    {
        private readonly ShopContext _context;

        public ShopsController(ShopContext context)
        {
            _context = context;
        }

        // GET: Shops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shops.ToListAsync());
        }


        // GET: Shops/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if(id==0)
            return View(new Shop());
            else
                return View(_context.Shops.Find(id));
        }

        // POST: Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("ItemId,SingerName,AlbumName,PopularSong,Homeland")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                if(shop.ItemId ==0)
                _context.Add(shop);
                else
                    _context.Update(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }



        // GET: Shops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var shop = await _context.Shops.FindAsync(id);
            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
