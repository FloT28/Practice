using System;
using System.Collections.Generic;
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

namespace Grid_view_filter_demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students;
        public MainWindow()
        {
            InitializeComponent();

            //reas csv file 
            var lines = File.ReadAllLines("D:\\Users\\270357713\\OneDrive - UP Education\\Documents\\BSE Y1 - 2024\\CS106 INTEGRATED STUDIO II Exam marks list.csv");

            students = new List<Student>();

            //skip the first header line
            for(var i = 1; i < lines.Length; i++)
            {
                //split each line into array of string 
                var line = lines[i].Split(',');

                //create new student and add to the student list 
                students.Add(new Student { FullNane = line[0], Mark = int.Parse(Line[1]), Grade = gradeConvert(int.Parse(line[1]))});
            }
            studentList.ItemsSource = students;
        }

        private void studentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            studentList.ItemsSource = (from s in students
                                       where s.FullName.Indexof(searchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       s.Grade.Indexof(searchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                       s.Mark.ToString().Indexof(searchBar.Text StringComparison.OrdinalIgnoreCase >= 0
                                       select s).ToList();
        }
        private string gradeConvert(int grade)
        {
            string returnGrade = "E";

            if (grade >= 40)  { return returnGrade = "D"; }
            if (grade >= 50)  { return returnGrade = "C-"; }
            if (grade >= 60)  { return returnGrade = "C"; }
            if (grade >= 70)  { return returnGrade = "C+"; }
            if (grade >= 80)  { return returnGrade = "B-"; }
            if (grade >= 90)  { return returnGrade = "B"; }
            if (grade >= 100) { return returnGrade = "B+"; }
            if (grade >= 120) { return returnGrade = "A-"; }
            if (grade >= 140) { return returnGrade = "A"; }
            if (grade >= 150) { return returnGrade = "A+"; }

            return returnGrade;
        }
        class Student
        {
            public string FullName { get; set; }
            public int Mark { get; set; }
            public string Grade { get; set; }

        }
    }

}
