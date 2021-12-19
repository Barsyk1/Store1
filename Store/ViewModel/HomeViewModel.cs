using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }
    }
}
