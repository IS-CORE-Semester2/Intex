using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intex.Models;
using Intex.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Intex
{
    //lock down controller so only admins and researchers can access MOST actions.
    //other actions can be unlocked by adding the "AllowAnonymous" tag helper
    [Authorize(Roles = "Admin,Researcher")]
    public class ExhumationsController : Controller
    {
        private readonly ExhumationDbContext _context;

        //hosting environment will help us with saving pictures and pictures paths
        private readonly IHostingEnvironment hostingEnvironment;

        public ExhumationsController(ExhumationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        //Allow anonymous access to this action
        [AllowAnonymous]
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            //create a new index view model to handle the DBSet and pagination
            return View(new IndexViewModel
            {
                Exhumations = _context.Exhumations
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalNumItems = (_context.Exhumations.Count())
                },
            });
        }

        // GET: Exhumations/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhumation = await _context.Exhumations
                .FirstOrDefaultAsync(m => m.BurialID == id);
            if (exhumation == null)
            {
                return NotFound();
            }

            return View(exhumation);
        }

        // GET: Exhumations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExhumationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                //generate a unique file name (using Guid) for the photo being saved (so that it doesn't overwrite any already saved)
                //save photos in the img/Exhumations folder
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "img/Exhumations");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                //copy all the existing exhumation data, along with the newly created photopath, to a new exhumation entry
                Exhumation newExhumation = new Exhumation
                {
                    LowPairNS = model.LowPairNS,
                    HighPairNS = model.HighPairNS,
                    BurialLocationNS = model.BurialLocationNS,
                    LowPairEW = model.LowPairEW,
                    HighPairEW = model.HighPairEW,
                    BurialLocationEW = model.BurialLocationEW,
                    Area = model.Area,
                    ShaftNumber = model.ShaftNumber,
                    BurialNumber = model.BurialNumber,
                    SouthToHeadInMeters = model.SouthToHeadInMeters,
                    SouthToFeetInMeters = model.SouthToFeetInMeters,
                    WestToHeadInMeters = model.WestToHeadInMeters,
                    WestToFeetInMeters = model.WestToFeetInMeters,
                    LengthInMeters = model.LengthInMeters,
                    DepthInMeters = model.DepthInMeters,
                    PhotoPath = uniqueFileName,
                    BurialGoods = model.BurialGoods,
                    Hair = model.Hair,
                    Age = model.Age,
                    BurialMaterials = model.BurialMaterials,
                    ExcavationRecorder = model.ExcavationRecorder,
                    Date = model.Date,
                    Time = model.Time
                };

                //add the new entry to the database and save it
                _context.Exhumations.Add(newExhumation);
                _context.SaveChanges();

                //send the person to the details page of what they just created
                return RedirectToAction("Details", new { id = newExhumation.BurialID });
            }

            return View();
        }

        // GET: Exhumations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhumation = await _context.Exhumations.FindAsync(id);            

            if (exhumation == null)
            {
                return NotFound();
            }
            return View(exhumation);
        }

        // POST: Exhumations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BurialID,LowPairNS,HighPairNS,BurialLocationNS,LowPairEW,HighPairEW,BurialLocationEW,Area,ShaftNumber,BurialNumber,SouthToHeadInMeters,SouthToFeetInMeters,WestToHeadInMeters,WestToFeetInMeters,LengthInMeters,DepthInMeters,PhotoPath,BurialGoods,Hair,Age,BurialMaterials,ExcavationRecorder,Date,Time")] Exhumation exhumation)
        {
            if (id != exhumation.BurialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhumation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhumationExists(exhumation.BurialID))
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
            return View(exhumation);
        }

        [AllowAnonymous]
        //Page to filter by ALL data in a database
        public IActionResult AllData()
        {
            return View(_context.Exhumations);
        }

        // GET: Exhumations/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhumation = await _context.Exhumations
                .FirstOrDefaultAsync(m => m.BurialID == id);
            if (exhumation == null)
            {
                return NotFound();
            }

            return View(exhumation);
        }

        // POST: Exhumations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhumation = await _context.Exhumations.FindAsync(id);
            _context.Exhumations.Remove(exhumation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExhumationExists(int id)
        {
            return _context.Exhumations.Any(e => e.BurialID == id);
        }
    }
}
