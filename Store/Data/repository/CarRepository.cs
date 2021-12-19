using Microsoft.EntityFrameworkCore;
using Store.Data.interfaces;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.repository
{
    public class CarRepository:IAllCars
    {
        private readonly ApplicationDbContext appDBContent;

        public CarRepository(ApplicationDbContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> getFaveCars => appDBContent.Car.Where(p => p.isFavorite).Include(c => c.Category);

        public Car getObjectCar(int carid) => appDBContent.Car.FirstOrDefault(p => p.id == carid);
    }
}
