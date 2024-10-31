using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
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

namespace Grid_view_sort
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
            var lines = File.ReadAllLines(@"..\..\..\Files\Exam marks list.csv");

            List<Student> students = new List<Student>();

            //skip the first header line
            for (var i = 1; i < lines.Length; i++)
            {
                //split each line into array of string
                var line = lines[i].Split(',');

                //create new student and add to the student list
                students.Add(new Student { FullName = line[0], Mark = int.Parse(line[1]), Grade = gradeConvert(int.Parse(line[1])) });
            }

            studentList.ItemsSource = students;

            studentList.Items.SortDescriptions.Add(new SortDescription("Mark", ListSortDirection.Descending));
            studentList.Items.SortDescriptions.Add(new SortDescription("FullName", ListSortDirection.Descending));

        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string selectedColumnName = column.Tag.ToString();

            bool isSelectedColumnBeenSorted = studentList.Items.SortDescriptions.Any(x => x.PropertyName == selectedColumnName);

            if (!isSelectedColumnBeenSorted)
            {
                studentList.Items.SortDescriptions.Clear();
                studentList.Items.SortDescriptions.Add(new SortDescription(selectedColumnName, ListSortDirection.Ascending));
            }
            else
            {
                ListSortDirection previousSortDirection = studentList.Items.SortDescriptions.Where(
                    x => x.PropertyName == selectedColumnName).Select(x => x.Direction).First();

                studentList.Items.SortDescriptions.Clear();

                if (previousSortDirection == ListSortDirection.Ascending)
                {
                    studentList.Items.SortDescriptions.Add(new SortDescription(selectedColumnName, ListSortDirection.Descending));
                }
                else
                {
                    studentList.Items.SortDescriptions.Add(new SortDescription(selectedColumnName, ListSortDirection.Ascending));
                }
            }
        }

        private string gradeConvert(int grade)
        {
            string returnGrade = "E";

            if (grade >= 40) { returnGrade = "D"; }
            if (grade >= 50) { returnGrade = "C-"; }
            if (grade >= 55) { returnGrade = "C"; }
            if (grade >= 60) { returnGrade = "C+"; }
            if (grade >= 65) { returnGrade = "B-"; }
            if (grade >= 70) { returnGrade = "B"; }
            if (grade >= 75) { returnGrade = "B+"; }
            if (grade >= 80) { returnGrade = "A-"; }
            if (grade >= 85) { returnGrade = "A"; }
            if (grade >= 90) { returnGrade = "A+"; }

            return returnGrade;
        }
    }

    class Student
    {
        public string FullName { get; set; }
        public int Mark { get; set; }
        public string Grade { get; set; }

    }
}

