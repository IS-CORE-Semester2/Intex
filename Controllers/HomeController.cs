using Intex.Data;
using Intex.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Controllers
{
    public class HomeController : Controller
    {
        //pull in DBContext and stuff here
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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

        //get request for bone books
        public IActionResult BoneBooks()
        {
            return View();
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
