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

namespace Intex.Controllers
{
    public class BioSamplesController : Controller
    {
        private readonly BioSamplesDbContext _context;

        public BioSamplesController(BioSamplesDbContext context)
        {
            _context = context;
        }

        // GET: BioSamples
        //public async Task<IActionResult> Index()
        //{
        //    var bioSamplesDbContext = _context.BioSamples.Include(b => b.Burial);
        //    return View(await bioSamplesDbContext.ToListAsync());
        //}


        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            return View(new IndexViewModel
            {
                BioSamples = _context.BioSamples
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalNumItems = (_context.BioSamples.Count())
                },
            });
        }


        // GET: BioSamples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSamples = await _context.BioSamples
                .Include(b => b.Burial)
                .FirstOrDefaultAsync(m => m.BioSampleId == id);
            if (bioSamples == null)
            {
                return NotFound();
            }

            return View(bioSamples);
        }

        // GET: BioSamples/Create
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.Set<Burials>(), "BurialId", "BurialId");
            return View();
        }

        // POST: BioSamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BioSampleId,RackNumber,BagNumber,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,BurialNumber,Date,PreviouslySampled,Notes,Initials,BurialId")] BioSamples bioSamples)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bioSamples);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.Set<Burials>(), "BurialId", "BurialId", bioSamples.BurialId);
            return View(bioSamples);
        }

        // GET: BioSamples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSamples = await _context.BioSamples.FindAsync(id);
            if (bioSamples == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.Set<Burials>(), "BurialId", "BurialId", bioSamples.BurialId);
            return View(bioSamples);
        }

        // POST: BioSamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BioSampleId,RackNumber,BagNumber,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,BurialNumber,Date,PreviouslySampled,Notes,Initials,BurialId")] BioSamples bioSamples)
        {
            if (id != bioSamples.BioSampleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bioSamples);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BioSamplesExists(bioSamples.BioSampleId))
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
            ViewData["BurialId"] = new SelectList(_context.Set<Burials>(), "BurialId", "BurialId", bioSamples.BurialId);
            return View(bioSamples);
        }

        // GET: BioSamples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSamples = await _context.BioSamples
                .Include(b => b.Burial)
                .FirstOrDefaultAsync(m => m.BioSampleId == id);
            if (bioSamples == null)
            {
                return NotFound();
            }

            return View(bioSamples);
        }

        // POST: BioSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bioSamples = await _context.BioSamples.FindAsync(id);
            _context.BioSamples.Remove(bioSamples);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BioSamplesExists(int id)
        {
            return _context.BioSamples.Any(e => e.BioSampleId == id);
        }
    }
}
