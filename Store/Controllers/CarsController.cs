using Microsoft.AspNetCore.Mvc;
using Store.Data.interfaces;
using Store.Models;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class CarsController:Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategorys;

        public CarsController(IAllCars iAllcars, ICarsCategory iCarsCat)
        {
            _allCars = iAllcars;
            _allCategorys = iCarsCat;
        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryname.Equals("Электромобили")).OrderBy(i => i.id);
                    currCategory = "Электромобили";
                }
                else
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryname.Equals("Классические автомобили")).OrderBy(i => i.id);
                    currCategory = "Классические автомобили";
                }


            }

            var carObj = new CarsListViewModel
            {
                allCars = cars,
                currCategory = currCategory
            };




            ViewBag.Title = "Страница с автомобилями";



            return View(carObj);
        }

    }
}
