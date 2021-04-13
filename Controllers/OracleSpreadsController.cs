using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intex;
using Intex.Models;
using Intex.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Intex.Controllers
{
    [Authorize(Roles = "Admin,Researcher")]
    public class OracleSpreadsController : Controller
    {
        private readonly OracleSpreadsDbContext _context;

        public OracleSpreadsController(OracleSpreadsDbContext context)
        {
            _context = context;
        }

        //// GET: OracleSpreads
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.OracleSpread.ToListAsync());
        //}
        [AllowAnonymous]
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            return View(new IndexViewModel
            {
                OracleSpreads = _context.OracleSpread
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalNumItems = (_context.OracleSpread.Count())
                },
            });
        }

        // GET: OracleSpreads/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oracleSpread = await _context.OracleSpread
                .FirstOrDefaultAsync(m => m.Gamous == id);
            if (oracleSpread == null)
            {
                return NotFound();
            }

            return View(oracleSpread);
        }

        // GET: OracleSpreads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OracleSpreads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Gamous,BurialSquare,Nors,Sq2,Eorw,Area,Burialnum,Westtohead,Westtofeet,Southtohead,Southtofeet,Depth,Preservation,Burialicon,Sex,Sexmethod,Ageatdeath,Agemethod,Haircolor,Sample")] OracleSpreads oracleSpreads)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oracleSpreads);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oracleSpreads);
        }

        // GET: OracleSpreads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oracleSpread = await _context.OracleSpread.FindAsync(id);
            if (oracleSpread == null)
            {
                return NotFound();
            }
            return View(oracleSpread);
        }

        // POST: OracleSpreads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Gamous,BurialSquare,Nors,Sq2,Eorw,Area,Burialnum,Westtohead,Westtofeet,Southtohead,Southtofeet,Depth,Preservation,Burialicon,Sex,Sexmethod,Ageatdeath,Agemethod,Haircolor,Sample")] OracleSpreads oracleSpread)
        {
            if (id != oracleSpread.Gamous)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oracleSpread);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OracleSpreadExists(oracleSpread.Gamous))
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
            return View(oracleSpread);
        }

        // GET: OracleSpreads/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oracleSpread = await _context.OracleSpread
                .FirstOrDefaultAsync(m => m.Gamous == id);
            if (oracleSpread == null)
            {
                return NotFound();
            }

            return View(oracleSpread);
        }

        // POST: OracleSpreads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var oracleSpread = await _context.OracleSpread.FindAsync(id);
            _context.OracleSpread.Remove(oracleSpread);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OracleSpreadExists(int? id)
        {
            return _context.OracleSpread.Any(e => e.Gamous == id);
        }
    }
}
