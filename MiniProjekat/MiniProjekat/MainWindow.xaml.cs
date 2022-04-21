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

namespace MiniProjekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<Data> data = DataManager.FetchGDP("annual", "1970-01-01", "2021-01-01");
            data.ForEach(x => Console.WriteLine(x.Date + " " + x.Value));
            InitializeComponent();
            //znaci da li je gdp ili prinos sto je boolean
            //koji tip izvestaja zeli
            //vreme od 
            //vreme do
        }

        private void ShowTableForParams(object sender, RoutedEventArgs e)
        {
            List<Data> data = null;
            DateTime startDate = DateTime.Parse(DateStart.Text);
            DateTime endDate = DateTime.Parse(DateEnd.Text);
            string reportchoice = ReportChoiceComboBox.SelectedItem.ToString().ToLower();
            if (GDPRadioButton.IsChecked == true)
            {
                data = DataManager.FetchGDP(reportchoice, startDate.ToString(), endDate.ToString());
            }
            else if (TreasuryRadioButton.IsChecked == true)
            {
                data = DataManager.FetchTreasury(reportchoice, startDate.ToString(), endDate.ToString());
            }
            else
            {
                MessageBox.Show("Niste izabrali nijedan skup podataka");
            }
            if (data.Count() > 0)
            { 
                TableInfo tableInfo = new TableInfo(data);
                tableInfo.Show();
            }
            else
            {
                MessageBox.Show("Nemamo podataka za odabrane velicine");
            }
        }
        private void GDPRadioButton_Click(object sender, RoutedEventArgs e)
        {
            ReportChoiceComboBox.Items.Clear();
            ComboBoxItem comboBoxItem1 = new ComboBoxItem();
            comboBoxItem1.Content = "Annual";
            ComboBoxItem comboBoxItem2 = new ComboBoxItem();
            comboBoxItem2.Content = "Quarterly";
            ReportChoiceComboBox.Items.Add(comboBoxItem1);
            ReportChoiceComboBox.Items.Add(comboBoxItem2);
            ReportChoiceComboBox.Items.Refresh();
        }

        private void TreasuryRadioButton_Click(object sender, RoutedEventArgs e)
        {
            ReportChoiceComboBox.Items.Clear();
            ComboBoxItem comboBoxItem1 = new ComboBoxItem();
            comboBoxItem1.Content = "Daily";
            ComboBoxItem comboBoxItem2 = new ComboBoxItem();
            comboBoxItem2.Content = "Weekly";
            ComboBoxItem comboBoxItem3 = new ComboBoxItem();
            comboBoxItem3.Content = "Mountly";
            ReportChoiceComboBox.Items.Add(comboBoxItem1);
            ReportChoiceComboBox.Items.Add(comboBoxItem2);
            ReportChoiceComboBox.Items.Add(comboBoxItem3);
            ReportChoiceComboBox.Items.Refresh();
        }
    }
}
