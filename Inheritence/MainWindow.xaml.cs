using System;
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

namespace Inheritence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> hospitalStaffList = new ObservableCollection<Employee>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGetEmployees_Click(object sender, RoutedEventArgs e)
        {
            //Employee emp1 = new Employee("Tom", "123 Meadow Lane", "071 91 1234567");
            //Employee emp2 = new Employee("Sally", "5a Seaview", "086 0101555");
            //Employee emp3 = new Employee("Jo", "Ash Lane", "085 123 4567");


            //Create some nurse objects
            Nurse nurse1 = new Nurse("Mary", "Hospital Road", "071 91 777 6666", 1, "Paediatrics");
            Nurse nurse2 = new Nurse("Sue", "Hospital Road", "071 91 888 7777", 2, "Casualty");

            //create some doctor objects
            Doctor doc1 = new Doctor("George", "Calry", "071 91 66554433", PositionType.Junior);
            Doctor doc2 = new Doctor("Alison", "John Street", "071 91 55 222", PositionType.Senior);


            //add employees to list
            //hospitalStaffList.Add(emp1);
            //hospitalStaffList.Add(emp2);
            //hospitalStaffList.Add(emp3);

            hospitalStaffList.Add(nurse1);
            hospitalStaffList.Add(nurse2);

            hospitalStaffList.Add(doc1);
            hospitalStaffList.Add(doc2);

            lbxEmployees.ItemsSource = hospitalStaffList;

        }

        private void WriteToFile(ObservableCollection<Employee> staff)
        {
            string[] employees = new string[staff.Count];

            Employee e;

            for (int i = 0; i < staff.Count; i++)
            {
                e = staff.ElementAt(i);
                employees[i] = e.FileFormat();
            }

            File.WriteAllLines(@"C:\Users\TEMP\Employees.txt", employees);
        }

        private void BtnSaveEmployees_Click(object sender, RoutedEventArgs e)
        {
            WriteToFile(hospitalStaffList);
        }

        //determine the types of objects in list
        private void BtnGetType_Click(object sender, RoutedEventArgs e)
        {
            int employees = 0, doctors = 0, nurses = 0;

            foreach (Employee emp in hospitalStaffList)
            {
                //if (emp is Nurse)
                //    nurses++;
                //else if (emp is Doctor)
                //    doctors++;
                //else if (emp is Employee)
                //    employees++;

                //if (emp as Nurse != null)
                //    nurses++;
                //else if (emp as Doctor != null)
                //    doctors++;
                //else if (emp as Employee != null)
                //    employees++;

                Type type = emp.GetType();

                if (type.Name == "Employee")
                    employees++;
                else if (type.Name == "Nurse")
                    nurses++;
                else if (type.Name == "Doctor")
                    doctors++;




            }

            string message = string.Format($"Employees:{employees} Doctors:{doctors} Nurses:{nurses}");

            MessageBox.Show(message);

        }

        private void BtnGetPay_Click(object sender, RoutedEventArgs e)
        {
            //determine what was selected
            Employee selectedEmployee = lbxEmployees.SelectedItem as Employee;

            if (selectedEmployee != null)
            {
                //calculate pay using GetMonthlyPay
                decimal pay = selectedEmployee.GetMonthlySalary();

                //Get Type
                Type type = selectedEmployee.GetType();  //includes namespace in name
                string typeName = type.Name;  //just give the class name

                //Show Message
                MessageBox.Show(string.Format($"Monthly pay of selected {typeName} is {pay:C}"));
            }

            else
            {
                MessageBox.Show("Nothing selected");
            }

        }
    }
}