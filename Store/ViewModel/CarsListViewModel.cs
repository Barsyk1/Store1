using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ViewModel
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }
        public string currCategory { get; set; }
    }
}
