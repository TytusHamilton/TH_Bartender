using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BartenderTH.Models
{
    public class OrdersContextInitializer : DropCreateDatabaseIfModelChanges<OrdersContext>
    {
        protected override void Seed(OrdersContext context)
        {
            var Drink = new List<drinks>()
            {
                new drinks() { Name = "Bloody Mary", Price = 4.99M, },
                new drinks() { Name = "Cosmopolitan", Price = 6.99M, },
                new drinks() { Name = "Martini", Price = 7.99M, },
            };

            Drink.ForEach(p => context.drinks.Add(p));
            context.SaveChanges();

            var Order = new order() { Customer = "Bob" };
            var od = new List<order>()
            {
                new order() { drinks = Drink[0], Quantity = 1},
                new order() { drinks = Drink[1], Quantity = 1}

            };
            context.Orders.Add(Order);
            od.ForEach(o => context.Orders.Add(o));

            context.SaveChanges();
        }
    }
}
