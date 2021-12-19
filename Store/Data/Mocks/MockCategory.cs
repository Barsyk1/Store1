using Store.Data.interfaces;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategorys
        {
            get
            {
                return new List<Category> {
                    new Category {categoryname="Электромобили",desc="Современный вид транспорта" },
                    new Category {categoryname="Классические автомобили",desc="Машины с двигателем внутреннего сгорания"}
                };
            }

        }
    }
}
