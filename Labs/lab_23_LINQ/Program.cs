using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_23_LINQ
{
    class Program
    {
        static List<Customer> customers;
        static void Main(string[] args)
        {
            //LINQ simple query

#if DEBUG
            Console.WriteLine("in debug mode..\n\n");
#endif

            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                db.Orders.ToList();
                db.Order_Details.ToList();

                //cannot print this
                //LINQ produces output of type IQueryable
                //This is an abstract type so we cast it to a list
                var output1 =
                    (from customer in db.Customers
                     select customer).ToList();

                Console.WriteLine("\n\nTrivial LINQ query");
                //output1.ForEach(c => Console.WriteLine($"{c.CustomerID,-5}") );
                //PrintCustomers(output1);

                var LINQWhere =
                    from customer in db.Customers
                    where customer.City == "London" || customer.City == "Berlin"
                    //orderby customer.City descending
                    select customer;
                //Console.WriteLine($"{"Customer ID", -12}{"City", -12}");
                //LINQWhere.ToList().ForEach(c => Console.WriteLine($"{c.CustomerID, -12}{c.City, -12}"));
                PrintCustomers(LINQWhere.ToList());

                //order by customer name
                var LINQOrderBy =
                    (from customer in db.Customers
                     where customer.City == "London"
                     orderby customer.ContactName descending
                     select customer).ToList();
                PrintCustomers(LINQOrderBy);


                Console.WriteLine("\n\nLambda has OrderBy..ThenBy\n");
                var LINQOrderByThenBy =
                    db.Customers.Where(c => c.City == "London" || c.City == "Berlin" || c.City == "Madrid")
                    .OrderBy(c => c.City)
                    .ThenBy(c => c.ContactName)
                    .ToList();
                PrintCustomers(LINQOrderByThenBy);


                Console.WriteLine("\n\nCreating A Custom Output Object");
                var CustomObject =
                    from c in db.Customers
                    join order in db.Orders
                        on c.CustomerID equals order.CustomerID
                    select new
                    {
                        Name = c.ContactName,
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        Ship_City = order.ShipCity
                    };
                CustomObject.ToList().ForEach(item => Console.WriteLine($"" +
                    $"{item.Name, -30}" +
                    $"{item.OrderDate:dd/MM/yyyy, -30}" +
                    $"{item.Ship_City, -10}"));


                //slick version : print only
                Console.WriteLine("\n\nJoining Orders To Customers Using Lambda");
                db.Orders.Where(o => o.Customer.City == "Berlin").ToList().ForEach(o =>
                {
                    Console.WriteLine($"{o.Customer.ContactName,-30}{o.Customer.City,-10}{o.OrderID,-15}{o.OrderDate:dd/MM/yyyy}");
                });



                Console.WriteLine("\n\nJoining 3 tables : Order details, Orders, Customers\n");
                db.Order_Details.Where(od => od.Order.Customer.City == "Berlin").ToList()
                    .ForEach(od =>
                    {
                        Console.WriteLine($"" +
                            $"{od.Order.Customer.ContactName, -20}" +
                            $"{od.Order.Customer.City, -15}" +
                            $"{od.OrderID, -15}" +
                            $"{od.Product.ProductName, -40}" +
                            $"{od.ProductID, -10}" + 
                            $"{od.Order.OrderDate:dd//MM//yyyy}");
                });
            }
        }

#region PrintBlock
        static void PrintCustomers(List<Customer> customersTemp)
        {
            var maxNameLength = customersTemp.Max(c => c.ContactName.Length) + 1;
            var maxAddressLength = customersTemp.Max(c => c.Address.Length) + 1;

            Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine($"{"ID".PadRight(10)}{"│",-3}{"Contact Name".PadRight(maxNameLength)}{"│",-3}{"Address".PadRight(30)}{"│",-3}{"City".PadRight(12)}");
            Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────");
            customersTemp.ForEach(c => Console.WriteLine($"{c.CustomerID.PadRight(10)}{"│",-3}{c.ContactName.PadRight(maxNameLength)}{"│",-3}{c.Address.PadRight(30)}{"│",-3}{c.City.PadRight(12)}"));
            //Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("\n\n");
        }
#endregion PrintBlock
    }
}

/*
 * db.Order_Details.Where(od => od.Order.Customer.City == "Berlin").ToList()
                    .ForEach(od =>
                    {
                        Console.WriteLine($"" +
                            $"{od.Order.Customer.ContactName, -20}" +
                            $"{od.Order.Customer.City, -15}" +
                            $"{od.OrderID, -15}" +
                            $"{od.ProductID, -10}" + 
                            $"{od.Order.OrderDate:dd//MM//yyyy}");
                });
*/