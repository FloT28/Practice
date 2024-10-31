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

namespace Listviw_databin
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
            var lines = File.ReadAllLines(@"D:\Users\270357713\OneDrive - UP Education\Documents\BSE Y1 - 2024\CS106 INTEGRATED STUDIO II\24.10.24 - Grid view filter\Grid view filter demo\Animal list.csv");

            List<AnimalItem> animalItems = new List<AnimalItem>();

            //skip the first header line
            for (var i = 1; i < lines.Length; i++)
            {
                //split each line into array of string
                var line = lines[i].Split(',');

                //create new animal item instance and add it to the animal list
                animalItems.Add(new
                    AnimalItem
                {
                    Name = line[0],
                    urlink = line[1]
                });
            }

            animalList.ItemsSource = animalItems;
        }
    }

    public class AnimalItem
    {
        public string Name { get; set; }
        public string urlink { get; set; }
    }

   
}
