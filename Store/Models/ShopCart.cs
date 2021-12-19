using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ShopCart
    {
        private readonly ApplicationDbContext appDBContent;

        public ShopCart(ApplicationDbContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string shopCartId = session.GetString("cartid") ?? Guid.NewGuid().ToString();

            session.SetString("cartid", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };

        }
        public void AddToCart(Car car)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCarId = ShopCartId,
                car = car,
                price = car.price

            });

            appDBContent.SaveChanges();

        }

        public List<ShopCartItem> getShopitems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCarId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
