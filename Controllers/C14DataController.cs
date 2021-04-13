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
    public class C14DataController : Controller
    {
        private readonly C14DataDbContext _context;

        public C14DataController(C14DataDbContext context)
        {
            _context = context;
        }
        
        //allow anonymous users access to the index page
        //set up pagination
        [AllowAnonymous]
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            return View(new IndexViewModel
            {
                //create a new index view model to handle the DBSet and pagination
                C14Datas = _context.C14Data
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalNumItems = (_context.C14Data.Count())
                },
            });
        }

        // GET: C14Data/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c14Data = await _context.C14Data
                .FirstOrDefaultAsync(m => m.BurialNumber == id);
            if (c14Data == null)
            {
                return NotFound();
            }

            return View(c14Data);
        }

        // GET: C14Data/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: C14Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurialNumber,Rack,NorthSouthNumber,NorthSouthLetter,EastWestNumber,EastWestLetter,Square,Area,TubeNumber,Description,SizeMl,Foci,C14Sample2017,Location,QuestionS,OtherNumber,Conventional14cAgeBp,_14cCalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] C14Data c14Data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(c14Data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(c14Data);
        }

        // GET: C14Data/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c14Data = await _context.C14Data.FindAsync(id);
            if (c14Data == null)
            {
                return NotFound();
            }
            return View(c14Data);
        }

        // POST: C14Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BurialNumber,Rack,NorthSouthNumber,NorthSouthLetter,EastWestNumber,EastWestLetter,Square,Area,TubeNumber,Description,SizeMl,Foci,C14Sample2017,Location,QuestionS,OtherNumber,Conventional14cAgeBp,_14cCalendarDate,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] C14Data c14Data)
        {
            if (id != c14Data.BurialNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(c14Data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!C14DataExists(c14Data.BurialNumber))
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
            return View(c14Data);
        }

        // GET: C14Data/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var c14Data = await _context.C14Data
                .FirstOrDefaultAsync(m => m.BurialNumber == id);
            if (c14Data == null)
            {
                return NotFound();
            }

            return View(c14Data);
        }

        // POST: C14Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var c14Data = await _context.C14Data.FindAsync(id);
            _context.C14Data.Remove(c14Data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool C14DataExists(int id)
        {
            return _context.C14Data.Any(e => e.BurialNumber == id);
        }

        //tableau stuff
        public IActionResult Visualization()
        {
            return View();


        }
    }
}
