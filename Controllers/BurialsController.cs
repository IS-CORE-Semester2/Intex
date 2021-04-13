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
    public class BurialsController : Controller
    {
        private readonly BurialsDbContext _context;

        public BurialsController(BurialsDbContext context)
        {
            _context = context;
        }

        // GET: Burials index page
        // add in support for pagination
        [AllowAnonymous]
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            //create a new index view model to handle the DBSet and pagination
            return View(new IndexViewModel
            {
                Burials = _context.Burials
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalNumItems = (_context.Burials.Count())
                },
            });
        }

        //Page to filter by ALL data in a database
        [AllowAnonymous]
        public IActionResult AllData()
        {
            return View(_context.Burials);
        }

        // GET: Burials/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burials = await _context.Burials
                .FirstOrDefaultAsync(m => m.BurialId == id);
            if (burials == null)
            {
                return NotFound();
            }

            return View(burials);
        }

        // GET: Burials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Burials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurialId,BurialLocation,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialSubplot,BurialDepth,SouthToHead,SouthToFeet,EastToHead,EastToFeet,BurialSituation,LengthOfRemains,BurialNumber,SampleNumber,GenderGe,GeFunctionTotal,GenderBodyCol,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,BoneLength,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,HairColor,PreservationIndex,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,YearFound,MonthFound,DayFound,HeadDirection")] Burials burials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burials);
        }

        // GET: Burials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burials = await _context.Burials.FindAsync(id);
            if (burials == null)
            {
                return NotFound();
            }
            return View(burials);
        }

        // POST: Burials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BurialId,BurialLocation,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialSubplot,BurialDepth,SouthToHead,SouthToFeet,EastToHead,EastToFeet,BurialSituation,LengthOfRemains,BurialNumber,SampleNumber,GenderGe,GeFunctionTotal,GenderBodyCol,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,BoneLength,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,HairColor,PreservationIndex,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,YearFound,MonthFound,DayFound,HeadDirection")] Burials burials)
        {
            if (id != burials.BurialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurialsExists(burials.BurialId))
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
            return View(burials);
        }

        // GET: Burials/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burials = await _context.Burials
                .FirstOrDefaultAsync(m => m.BurialId == id);
            if (burials == null)
            {
                return NotFound();
            }

            return View(burials);
        }

        // POST: Burials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var burials = await _context.Burials.FindAsync(id);
            _context.Burials.Remove(burials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurialsExists(int id)
        {
            return _context.Burials.Any(e => e.BurialId == id);
        }

        //tableau stuff
        [AllowAnonymous]
        public IActionResult Visualization()
        {
            return View();
        }

        //Allow people to go to a page to get their questions answered
        [AllowAnonymous]
        public IActionResult Questions()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult AnswersHeadDirection()
        {
            return View(new AnswersViewModel
            {
                Burials = _context.Burials
                    .Where(b => b.HeadDirection != null)
                    .OrderBy(b => b.BurialDepth)
                });
        }

        [AllowAnonymous]
        public IActionResult AnswersAgeWithJewelry()
        {
            return View(new AnswersViewModel
            {
                Burials = _context.Burials
                    .Where(b => b.ArtifactsDescription.Contains("necklace") || b.ArtifactsDescription.Contains("bracelet") || b.ArtifactsDescription.Contains("bead"))
                    .OrderBy(b => b.EstimateAge)
            });
        }

        [AllowAnonymous]
        public IActionResult AnswersGenderWithJewelry()
        {
            return View(new AnswersViewModel
            {
                Burials = _context.Burials
                    .Where(b => b.ArtifactsDescription.Contains("necklace") || b.ArtifactsDescription.Contains("bracelet") || b.ArtifactsDescription.Contains("bead"))
                    .OrderBy(b => b.GenderGe)
            });
        }

        [AllowAnonymous]
        public IActionResult AnswersAverageHeight()
        {
            return View(new AnswersViewModel
            {
                Burials = _context.Burials
                    .OrderBy(b => b.EstimateLivingStature)
                    .Where(b => b.EstimateLivingStature != null)
            });
        }

        [AllowAnonymous]
        public IActionResult AnswersHairColorByLocation()
        {
            return View(new AnswersViewModel
            {
                Burials = _context.Burials
                    .Where(b => b.HairColor != null)
                    .OrderBy(b => b.BurialLocation).ThenBy(b => b.BurialDepth)
            });
        }

        [AllowAnonymous]
        public IActionResult AnswersBuriedWithTextiles()
        {
            return View(new AnswersViewModel
            {
                Burials = _context.Burials
                    .Where(b => b.BurialSituation.Contains("textile"))
                    .OrderBy(b => b.GenderGe)
            });
        }

        [AllowAnonymous]
        public IActionResult AnswersFoundIn2000()
        {
            return View(new AnswersViewModel
            {
                Burials = _context.Burials
                    .Where(b => b.YearFound.Contains("2000"))
                    .OrderBy(b => b.BurialDepth)
            });
        }

        [AllowAnonymous]
        public IActionResult AnswersOpenCranialSutures()
        {
            return View(new AnswersViewModel
            {
                Burials = _context.Burials
                    .Where(b => b.CranialSuture.Contains("Open"))
                    .OrderBy(b => b.BurialDepth)
            });
        }
    }
}


