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

namespace list_view_cont
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
            var productFile = File.ReadAllLines(@"");
            var orderFile = File.ReadAllLines(@"");

            //create product and order lists
            List<Product> products = new List<Product>();
            List<Order> orders = new List<Order>();

            //skup the first header line
            for (var i = 1; i < productFile[i].Length; i++)
            {
                //split each line into array of string
                var line = productFile[i].Split(',');

                //create new prodyct and add to the product list
                products.Add(new Product
                {
                    IDataObject = int.Parse(line[0]),
                    Name = line[1],
                    Price = double.Parse(line[2]),
                });

                //skip the first header line
                for(var i = 1; i < orderFile.Length; i++)
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

                //preform the query
                var list  = (from o in orders 
                             joing p in products
                    on o.ProdyctId equals p.Id
                    select new
                    {
                        OrderId = o.Id,
                        ProductName = p.Name,
                        Quantity = o.Quantity,
                        TotalCost = o.Quantity * p.Price
                    }.ToList();
                sellList.ItemsSource = list;
            }
        }

        class 
    }
}
