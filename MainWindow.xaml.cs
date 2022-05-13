using System;
using System.Collections.Generic;
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
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.Entity;
using System.Configuration;
using System.Collections.ObjectModel;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionstring;
        TransBaseEntities tbe;
        ObservableCollection<Substation> substat;
        public MainWindow()
        {
            InitializeComponent();
           // List<string> ls=new List<string>(){"1","2","3"};
           // treeView.ItemsSource = ls;
            /*TreeViewItem tvi = new TreeViewItem();
            tvi.Items.Add("*");
            tvi.Header = "4";
            treeView.Items.Add(tvi);
            TreeViewItem tv1 = new TreeViewItem();
            tv1.Items.Add("6");
            tv1.Header = "5";
            treeView.Items.Add(tv1);*/
            connectionstring=ConfigurationManager.ConnectionStrings["TransBaseEntities"].ConnectionString;
            tbe = new TransBaseEntities();
            if (tbe.Database.Exists())
            {
                System.Windows.MessageBox.Show(connectionstring);
            }
            var sub=tbe.Substations.ToList<Substation>();

            substat = new ObservableCollection<Substation>(tbe.Substations.ToList<Substation>());





           // treeView.ItemsSource = substat;//привязываем treeview к коллекции

    


            foreach (var a in sub)
            {
                System.Windows.MessageBox.Show(a.SubstationAdress);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SubstationForm substationForm = new SubstationForm();
            substationForm.ShowDialog();
        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutBox1 abx = new AboutBox1();
            abx.ShowDialog();
        }


        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            TestForm tsf = new TestForm();
            tsf.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ControllerForm ctf = new ControllerForm();
            ctf.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            TransForm ctf = new TransForm();
            ctf.ShowDialog();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Substation s = new Substation();
            s.SubstationNumber=223;
            s.SubstationAdress="г. Энск";
            substat.Add(s);
            tbe.Substations.Add(s);
            tbe.SaveChanges();
        }
    }
}
