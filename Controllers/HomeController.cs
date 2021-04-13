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

        //hosting environment will help us save photos and photo paths
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

        //get request for data upload page
        [HttpGet]
        public IActionResult PDFDataUpload(int fileId, string category)
        {
            //pass in the category and fileId for the accordian menu that the user clicked on. Save to viewbag for use in post request
            ViewBag.fileId = fileId;
            ViewBag.category = category;

            return View();
        }

        //Post request for adding PDF Files
        [HttpPost]
        public IActionResult PDFDataUpload(PDFUploadViewModel model, int fileId, string category)
        {
            //error catcher. If the user clicked the "upload" button without selecting a file, return to them the same page, and pass the category and fileId so those don't get los
            if(model.PDFFiles == null)
            {
                ViewBag.fileId = fileId;
                ViewBag.category = category;

                return View();
            }

            //save the file the user wants to upload to the correct place on the server
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.PDFFiles != null)
                {
                    string uploadsFolder = null;

                    //create the correct path to save the file based on which accordian box the user clicked on
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

                //create a new pdf file object. Save the path, name, and FileId
                PDFFile newPDFFile = new PDFFile
                {
                    Path = uniqueFileName,
                    Name = model.PDFFiles.FileName,
                    FileId = fileId
                };

                //add the object to the database and save it
                _context.PDFFiles.Add(newPDFFile);
                _context.SaveChanges();

                //return the user to the PDF data page with the context file
                return RedirectToAction("PDFData", _context.PDFFiles);
            }
            return View();
        }

        //Post request to delete a file from the DB. Only allow an Admin to do this
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            //get the file to delete form the database based on the Id
            PDFFile fileToDelete = _context.PDFFiles.Where(p => p.Id == id).FirstOrDefault();

            //remove the file, save the changes
            _context.PDFFiles.Remove(fileToDelete);
            _context.SaveChanges();

            //return the view with the PDF table information
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
