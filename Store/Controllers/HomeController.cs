using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Logging;
using Store.Data.interfaces;
using Store.Models;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlLocalizer<HomeController> _localizer;
        

        private readonly IAllCars _carRep;


        public HomeController(IAllCars carRep, IHtmlLocalizer<HomeController> localizer)
        {
            _carRep = carRep;
            _localizer = localizer;

        }

        public ViewResult Index()
        {
            var test = _localizer["Best"];
            ViewData["Best"] = test;


            var homeCars = new HomeViewModel
            {
                favCars = _carRep.getFaveCars
            };
            return View(homeCars);

            

        }
        
        [HttpPost]
        public IActionResult CultureManagement(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return RedirectToAction(nameof(Index));
        }
    }
}
