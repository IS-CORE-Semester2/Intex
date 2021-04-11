using Intex.Data;
using Intex.Models;
using Intex.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
        {
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

        //create action for adding Bone Book Files
        [HttpPost]
        public IActionResult PDFDataUpload(PDFUploadViewModel model, int fileId)
        {
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
