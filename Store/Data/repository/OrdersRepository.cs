
using Store.Data.interfaces;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly ApplicationDbContext appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(ApplicationDbContext appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var items = shopCart.listShopItems;

            foreach (var el in items)
            {
                var ordeDetail = new OrderDetail()
                {
                    carID = el.car.id,
                    orderID = order.id,
                    price = (uint)el.car.price
                };

                appDBContent.OrderDetails.Add(ordeDetail);
            }
            appDBContent.SaveChanges();
        }

    }

}
