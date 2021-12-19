using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.interfaces
{
   public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> getFaveCars { get; }
        Car getObjectCar(int carid);
    }
}
