using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;
using NetCore2Shop.web.Models;

namespace NetCore2Shop.web.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepo productRepo;
        public HomeController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
