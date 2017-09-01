/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BartenderTH.Models
{
    public class DrinksContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var drinks = new List<drinks>()
            {
                new drinks() { Name = "Manhattan",Category = "cocktail", Price = 5.99M},
                new drinks() { Name = "Cosmopolitan",Category = "cocktail", Price = 6.99M},
                new drinks() { Name = "Bloody Mary",Category = "cocktail", Price = 7.99M}
            };

            drinks.ForEach(p => context.drinks.Add(p));
            context.SaveChanges();

            /*var Order = new order();
            var od = new List<order>()
            {
                new order() { drinks = products[0], Order = order},
                new order() { drinks = products[1], drinks = drink }
            };
            context.Orders.Add(Order);
            od.ForEach(o => context.Orders.Add(o));
            */
            //context.SaveChanges();
            /*
        }
    }
}
*/