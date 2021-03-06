using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data
{
    public class DBObj
    {
        public static void Inital(ApplicationDbContext content)
        {

            


            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
            if (!content.Car.Any())
            {
                content.AddRange(
                  new Car
                  {
                      name = "Tesla",
                      shortDesc = "Тесла Модель S является революционным электрическим автомобилем",
                      logDesc = "Машина впервые смогла доказать всем, что электромотор обладает огромным превосходством над ДВС, который уже изрядно устарел.",
                      img = "/img/Tesla.jpg",
                      price = 45000000,
                      isFavorite = true,
                      available = true,
                      Category = Categories["Электромобили"]
                  },
                    new Car
                    {
                        name = "Chevrolet Tahoe",
                        shortDesc = "Рамные полноразмерные внедорожники американской компании General Motors, созданные на агрегатах пикапов.",
                        logDesc = "Выпускаются отделениями Chevrolet с 1995 года и GMC с 1992 года, соответственно. Эти же автомобили, но с увеличенной колёсной базой называются Chevrolet Suburban и GMC Yukon XL.",
                        img = "/img/Tahoe.jpeg",
                        price = 29000000,
                        isFavorite = false,
                        available = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        name = "Ford Mustang",
                        shortDesc = "Культовый автомобиль класса Pony Car производства Ford Motor Company",
                        logDesc = "На автомобиле размещается не эмблема Ford, а специальная эмблема Mustang. Изначальный вариант 11233 был создан на базе агрегатов семейного седана Ford Falcon.",
                        img = "/img/Mustang.jpg",
                        price = 35000000,
                        isFavorite = true,
                        available = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        name = "Nissan Leaf",
                        shortDesc = "Электромобиль японского концерна Nissan, серийно выпускаемый с весны 2010 года",
                        logDesc = "Мировая премьера состоялась на международном Токийском автосалоне в 2009 году. Заказы на модель японские и американские дилеры компании начали принимать 1 апреля 2010 года, сборка первых серийных экземпляров началась в Японии, затем с 2012 года Nissan",
                        img = "/img/f.jpeg",
                        price = 46000000,
                        isFavorite = false,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        name = "Toyota Tundra",
                        shortDesc = "Полноразмерный пикап, выпускаемый Toyota Motor Corporation с 1999 года",
                        logDesc = "отя и сходное по размерам с T100, первое поколение Tundra имело более американский внешний вид и двигатель V8, которого не было у T100.",
                        img = "/img/Tundra.jpg",
                        price = 49000000,
                        isFavorite = false,
                        available = true,
                        Category = Categories["Классические автомобили"]
                    }



               );

            }
            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category {categoryname="Электромобили",desc="Современный вид транспорта" },
                        new Category {categoryname="Классические автомобили",desc="Машины с двигателем внутреннего сгорания"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.categoryname, el);
                    }

                }
                return category;
            }
        }
    }
}
