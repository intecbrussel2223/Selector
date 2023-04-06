using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Selector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string filePath = Directory.GetCurrentDirectory() +"\\Studenten.txt";

        List<Student> students = new List<Student>();

        public MainWindow()
        {
            InitializeComponent();
            lstAllStudents.Items.Clear();
            ItemAdd();
            
        }

        private void ItemAdd()
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();


            foreach (string line in lines)
            {
                string[] entries = line.Split(';');

                Student student = new Student();
                student.Level = int.Parse(entries[0]);
                student.FirstName = entries[1];
                student.LastName = entries[2];

                students.Add(student);
            }
            foreach (Student student in students)
            {
                lstAllStudents.Items.Add(student);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Student> temp = new List<Student>();
            var rnd = new Random();
            var index = rnd.Next(0, students.Count);
            Student newGroup = new Student();
            foreach (Student item in students.ToList())
            {
                if (item.Level == 1)
                {
                    newGroup = students[index];
                    temp.Add(newGroup);
                    students.RemoveAt(index);

                }
            }
            var iteration = 3; 
            foreach (var item in students)
            {
                index = rnd.Next(0, students.Count);
                while (iteration <= 3)
                    {
                        if (students[index].Level != 1)
                        {
                            newGroup = students[index];
                            temp.Add(newGroup);

                            students.RemoveAt(index);
                        iteration++;
                        }
                    continue;
                    }
            }
            lstGroup.Items.Add(newGroup);
            foreach (var item in temp)
            {
                lstGroup.Items.Add(item);   
            }
        }
    }
}
