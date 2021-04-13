using Intex.Data;
using Intex.Models;
using Intex.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Controllers
{
    public class HomeController : Controller
    {
        //pull in DBContext and stuff here
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        //get request for home page
        public IActionResult Index()
        //public IActionResult Index(string id)
        {
            //    var filters = new Filters(id);
            //    ViewBag.Filters = filters;
            //    ViewBag.BurialLocationNs = _context.Burials.BurialLocationNs.ToList();
            //    ViewBag.BurialLocationEw = _context.Burials.BurialLocationEw.ToList();
            //    ViewBag.BurialDepth = _context.Burials.BurialDepth.ToList();
            //    ViewBag.YearFound = _context.Burials.YearFound.ToList();
            //    ViewBag.HeadDirection = _context.Burials.HeadDirection.ToList();
            //    ViewBag.HairColor = _context.Burials.HairColor.ToList();
            //    ViewBag.HeadDirectionFilters = Filters.HeadDirectionFilterValues;

            //    //confused about how to work this part
            //    IQueryable<Burials> query = _context.Burials
            //        .Include(t => t.Category).Include(t => t.Status);

            //    if (filters.HasBurialLocationNs)
            //    {
            //        query = query.Where(t => t.BurialLocationNs == filters.BurialLocationNs);
            //    }

            //    if (filters.HasBurialLocationEw)
            //    {
            //        query = query.Where(t => t.BurialLocationEw == filters.BurialLocationEw);
            //    }

            //    //don't know if we can filter by depth unless we do it as a range
            //    if (filters.HasBurialDepth)
            //    {
            //        query = query.Where(t => t.BurialDepth == filters.BurialDepth);
            //    }
            //    if (filters.HasYearFound)
            //    {
            //        query = query.Where(t => t.YearFound == filters.YearFound);
            //    }
            //    if (filters.HasHeadDirection)
            //    {
            //        query = query.Where(t => t.HeadDirection == filters.HeadDirection);
            //    }
            //    if (filters.HasHairColor)
            //    {
            //        query = query.Where(t => t.HairColor == filters.HairColor);
            //    }

            //    var burials = query.OrderBy(t => t.YearFound).ToList();

            //    return View(burials);
            //
            return View();
        }

        //get request for PDFData
        public IActionResult PDFData()
        {
            return View(_context.PDFFiles);
        }


        [HttpGet]
        public IActionResult PDFDataUpload(int fileId, string category)
        {
            ViewBag.fileId = fileId;
            ViewBag.category = category;

            return View();
        }

        //Post request for adding PDF Files
        [HttpPost]
        public IActionResult PDFDataUpload(PDFUploadViewModel model, int fileId, string category)
        {
            if(model.PDFFiles == null)
            {
                ViewBag.fileId = fileId;
                ViewBag.category = category;

                return View();
            }

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.PDFFiles != null)
                {
                    string uploadsFolder = null;

                    if (fileId == 1)
                    {
                        uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "pdf/Osteology Data");
                    }
                    else if (fileId == 2)
                    {
                        uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "pdf/Field Books");
                    }
                    else if (fileId == 3)
                    {
                        uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "pdf/Archaeological Database Articles");
                    }
                    else
                    {
                        uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "pdf/Misc Data");
                    }

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PDFFiles.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.PDFFiles.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                PDFFile newPDFFile = new PDFFile
                {
                    Path = uniqueFileName,
                    Name = model.PDFFiles.FileName,
                    FileId = fileId
                };

                _context.PDFFiles.Add(newPDFFile);
                _context.SaveChanges();
                return RedirectToAction("PDFData", _context.PDFFiles);
            }
            return View();
        }

        //Post request to delete a file from the DB
        [HttpPost]
        public async Task<IActionResult> DeleteFile(int id)
        {
            PDFFile fileToDelete = _context.PDFFiles.Where(p => p.Id == id).FirstOrDefault();

            _context.PDFFiles.Remove(fileToDelete);
            _context.SaveChanges();
            return View("PDFData", _context.PDFFiles);
            
        }


        //get request for privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
