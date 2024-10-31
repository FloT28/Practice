using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Grid_style_demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //read the csv file
            var productFile = File.ReadAllLines(@"..\..\..\Files\Products.csv");
            var orderFile = File.ReadAllLines(@"..\..\..\Files\Orders.csv");

            //Create product and order lists
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();

            //skip the first header line
            for (var i = 1; i < productFile.Length; i++)
            {
                //split each line into array of string
                var line = productFile[i].Split(',');

                //create new product and add to the product list
                products.Add(new Product
                {
                    Id = int.Parse(line[0]),
                    Name = line[1],
                    Price = double.Parse(line[2])
                });
            }

            //skip the first header line
            for (var i = 1; i < orderFile.Length; i++)
            {
                //split each line into array of string
                var line = orderFile[i].Split(',');

                //create new order and add to the order list
                orders.Add(new Order
                {
                    Id = int.Parse(line[0]),
                    ProductId = int.Parse(line[1]),
                    Quantity = int.Parse(line[2])
                });
            }
            //Perfrom the query 
            var list = (from o in orders
                            join p in products
                            on o.ProductId equals p.Id
                            select new
                            {
                                ProductID = p.Id,
                                ProductName = p.Name,
                                Quantity = o.Quantity,
                                TotalCost = o.Quantity * p.Price
                            }).GroupBy(x => x.ProductID).Select(x => new
                            {
                                OrderID = x.Key,
                                ProductName = x.Select(a => a.ProductName).FirstOrDefault(),
                                Quantity = x.Select(a => a.Quantity).Sum(),
                                TotalCost = x.Select(a => a.TotalCost).Sum(),
                            }).ToList();

                sellList.ItemsSource = list;
            }
        }

        class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
        }

        class Order
        {
            public int ProductId { get; set; }
            public string Id { get; set; }
            public string Quantity { get; set; }
        }
    }
}
