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

namespace Ex5_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<BankAccount> CustomerAccounts = new ObservableCollection<BankAccount>();
        public MainWindow()
        {
            InitializeComponent();

            SavingsRate r1 = new SavingsRate("John McDonald", "11255247", "901114", 0.00M, 13.00M);
            SavingsRate r2 = new SavingsRate("Jim McDonald", "11255246", "901117", 55000.00M, 11.50M);
            SavingsRate r3 = new SavingsRate("Joe McDonald", "11255245", "901116", 500.00M, 13.00M);
            SavingsRate r4 = new SavingsRate("Mary McDonald", "11255248", "901115", 100.00M, 10.00M);
            SavingsRate r5 = new SavingsRate("Molly McDonald", "11255249", "901113",1500.00M, 4.00M);
            SavingsRate r6 = new SavingsRate("Maisy McDonald", "11255244", "901112", 3000.00M, 8.00M);

            CustomerAccounts.Add(r1);
            CustomerAccounts.Add(r2);
            CustomerAccounts.Add(r3);
            CustomerAccounts.Add(r4);
            CustomerAccounts.Add(r5);
            CustomerAccounts.Add(r6);
            LbxAccounts.ItemsSource = CustomerAccounts;
        }
        private void WriteToFile(ObservableCollection<BankAccount> accounts )
        {
            string[] Accounts = new string[accounts.Count];

           BankAccount r;

            for (int i = 0; i < accounts.Count; i++)
            {
                r = accounts.ElementAt(i);
                Accounts[i] = r.FileFormat();
            }

            File.WriteAllLines(@"C:\Users\TEMP\Employees.txt", Accounts);
        }


    }
}
