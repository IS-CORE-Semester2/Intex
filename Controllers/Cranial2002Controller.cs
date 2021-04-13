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
    //lock down controller so only admins and researchers can access MOST actions.
    //other actions can be unlocked by adding the "AllowAnonymous" tag helper
    [Authorize(Roles = "Admin,Researcher")]
    public class Cranial2002Controller : Controller
    {
        private readonly Cranial2002DbContext _context;

        //pull in context file to allow us to use the database
        public Cranial2002Controller(Cranial2002DbContext context)
        {
            _context = context;
        }

        //Allow anonymous access to this action
        [AllowAnonymous]
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            //create a new index view model to handle the DBSet and pagination
            return View(new IndexViewModel
            {
                Cranial2002s = _context.Cranial2002
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalNumItems = (_context.Cranial2002.Count())
                },
            });
        }

        // GET: Cranial2002/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cranial2002 = await _context.Cranial2002
                .FirstOrDefaultAsync(m => m.SampleNumber == id);
            if (cranial2002 == null)
            {
                return NotFound();
            }

            return View(cranial2002);
        }

        // GET: Cranial2002/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cranial2002/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SampleNumber,MaximumCranialLength,MaximumCranialBreadth,BasionBreg,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,BurialPositioningNorthSouthNumber,BurialPositioningNorthSouthDirection,BurialPositioningEastWestNumber,BurialPositioningEastWestDirection,BurialNumber,BurialDepth,BurialSubPlotDirection,BurialArtifactDescription,BuriedWithArtifacts,GilesGender,BodyGender")] Cranial2002 cranial2002)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cranial2002);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cranial2002);
        }

        // GET: Cranial2002/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cranial2002 = await _context.Cranial2002.FindAsync(id);
            if (cranial2002 == null)
            {
                return NotFound();
            }
            return View(cranial2002);
        }

        // POST: Cranial2002/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("SampleNumber,MaximumCranialLength,MaximumCranialBreadth,BasionBreg,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,BurialPositioningNorthSouthNumber,BurialPositioningNorthSouthDirection,BurialPositioningEastWestNumber,BurialPositioningEastWestDirection,BurialNumber,BurialDepth,BurialSubPlotDirection,BurialArtifactDescription,BuriedWithArtifacts,GilesGender,BodyGender")] Cranial2002 cranial2002)
        {
            if (id != cranial2002.SampleNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cranial2002);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cranial2002Exists(cranial2002.SampleNumber))
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
            return View(cranial2002);
        }

        // GET: Cranial2002/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cranial2002 = await _context.Cranial2002
                .FirstOrDefaultAsync(m => m.SampleNumber == id);
            if (cranial2002 == null)
            {
                return NotFound();
            }

            return View(cranial2002);
        }

        // POST: Cranial2002/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var cranial2002 = await _context.Cranial2002.FindAsync(id);
            _context.Cranial2002.Remove(cranial2002);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cranial2002Exists(int? id)
        {
            return _context.Cranial2002.Any(e => e.SampleNumber == id);
        }

        //tableau stuff
        public IActionResult Visualization()
        {
            return View();


        }
    }
}
