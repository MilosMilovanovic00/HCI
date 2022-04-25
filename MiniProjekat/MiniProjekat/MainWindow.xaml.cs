using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
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
        public List<Data> data { get; set; }
        public ChartData lineChart { get; set; }

        public MainWindow()
        {
            lineChart = new ChartData();
            InitializeComponent();
        }

        private string getReportInterval(String reportChoice)
        {
            
            if (reportChoice.ToLower() == "godišnji")
            {
                return "annual";
            }
            else if (reportChoice.ToLower() == "mesečni")
            {
                return "monthly";
            }
            else if(reportChoice.ToLower() == "tromesečni")
            {
                return "quarterly";
            }
            else if (reportChoice.ToLower() == "dnevni")
            {
                return "daily";
            }
            else if (reportChoice.ToLower() == "nedeljni")
            {
                return "weekly";
            }
            else
            {
                return null;
            }
        }

        private bool AreParametersValid()
        {
            if (GDPRadioButton.IsChecked == true || TreasuryRadioButton.IsChecked == true)
            {
                if (DateStart.Text != "" && DateEnd.Text != "" && ReportChoiceComboBox.SelectedItem != null)
                {
                    return true;
                }
            }
            MessageBox.Show("Sva polja moraju biti popunjena.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;

        }

        private void ShowGraph(object sender, RoutedEventArgs e)
        {
            if (AreParametersValid())
            {
                FetchData();
                if (data == null)
                {
                    MessageBox.Show("Komunikacija sa API-jem nije uspostavljena, pokušajte ponovo sa istim parametrima.", "Greška", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                else if (data.Count == 0)
                {
                    MessageBox.Show("Ne postoje podaci za odabrane parametre.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else
            {
                return;
            }

            lineChart.reset();

            ChartValues<double> values = new ChartValues<double>();

            foreach ( Data d in data)
            {
                values.Add(Double.Parse(d.Value));
                lineChart.labels.Add(d.Date);
            }
            if (data.Count > 1)
            {
                lineChart.lineSeriesCollection.Add(new LineSeries()
                {
                    Title = "Vrednost",
                    Values = values,
                    Configuration = new CartesianMapper<double>().Y(value => value).Stroke(value => (value == values.Max()) ? Brushes.LightGreen : (value == values.Min()) ? Brushes.LightPink: Brushes.CornflowerBlue).Fill(value => (value == values.Max()) ? Brushes.LightGreen : (value == values.Min()) ? Brushes.LightPink : Brushes.AliceBlue),                                                                                     
                    PointGeometry = DefaultGeometries.Diamond,
                    PointGeometrySize = 8,
                });

                lineChart.columnSeriesCollection.Add(new ColumnSeries()
                {
                    Title = "Vrednost",
                    Values = values,
                    Configuration = new CartesianMapper<double>().Y(value => value).Stroke(value => (value == values.Max()) ? Brushes.LightGreen : (value == values.Min()) ? Brushes.LightPink : Brushes.CornflowerBlue).Fill(value => (value == values.Max()) ? Brushes.LightGreen : (value == values.Min()) ? Brushes.LightPink : Brushes.AliceBlue),
                    PointGeometry = DefaultGeometries.Diamond
            
                });
            }
            else
            {
                lineChart.lineSeriesCollection.Add(new LineSeries()
                {
                    Title = "Vrednost",
                    Values = values,              
                    PointGeometry = DefaultGeometries.Diamond,
                    PointGeometrySize = 8,
                });

                lineChart.columnSeriesCollection.Add(new ColumnSeries()
                {
                    Title = "Vrednost",
                    Values = values,                  
                    PointGeometry = DefaultGeometries.Diamond
                });
            }

            DataContext = this;

            var lineChartObject = (CartesianChart) this.FindName("LineChart");
            lineChartObject.HideLegend();

            ShowTableButton.IsEnabled = true;


        }

        private void FetchData()
        {
            DateTime startDate = DateTime.Parse(DateStart.Text);
            DateTime endDate = DateTime.Parse(DateEnd.Text);
            string interval = getReportInterval(ReportChoiceComboBox.SelectedItem.ToString().Split(':')[1].Substring(1));

            if (GDPRadioButton.IsChecked == true)
            {
                data = DataManager.FetchGDP(interval, startDate.ToString(), endDate.ToString());
            }
            else if (TreasuryRadioButton.IsChecked == true)
            {
                data = DataManager.FetchTreasury(interval, startDate.ToString(), endDate.ToString());
                
            }
        }

        private void ShowTableForParams(object sender, RoutedEventArgs e)
        {

            if (data == null) {
                MessageBox.Show("Greška u komunikaciji sa API-jem. Pritisnite prikaži opet, pre nego što želite da pogledate tabelarni prikaz.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (data.Count() > 0)
            {
                TableInfo tableInfo = new TableInfo(data);
                tableInfo.Show();
            }
            else
            {
                MessageBox.Show("Ne postoje podaci za odabrane parametre.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void GDPRadioButton_Click(object sender, RoutedEventArgs e)
        {
            ReportChoiceComboBox.Items.Clear();
            ComboBoxItem comboBoxItem1 = new ComboBoxItem();
            comboBoxItem1.Content = "Godišnji";
            ComboBoxItem comboBoxItem2 = new ComboBoxItem();
            comboBoxItem2.Content = "Tromesečni";
            ReportChoiceComboBox.Items.Add(comboBoxItem1);
            ReportChoiceComboBox.Items.Add(comboBoxItem2);
            ReportChoiceComboBox.Items.Refresh();
        }

        private void TreasuryRadioButton_Click(object sender, RoutedEventArgs e)
        {
            ReportChoiceComboBox.Items.Clear();
            ComboBoxItem comboBoxItem1 = new ComboBoxItem();
            comboBoxItem1.Content = "Dnevni";
            ComboBoxItem comboBoxItem2 = new ComboBoxItem();
            comboBoxItem2.Content = "Nedeljni";
            ComboBoxItem comboBoxItem3 = new ComboBoxItem();
            comboBoxItem3.Content = "Mesečni";
            ReportChoiceComboBox.Items.Add(comboBoxItem1);
            ReportChoiceComboBox.Items.Add(comboBoxItem2);
            ReportChoiceComboBox.Items.Add(comboBoxItem3);
            ReportChoiceComboBox.Items.Refresh();
        }

        private void DateStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            checkRangeChangeEndDate();

        }

        private void checkRangeChangeEndDate()
        {
            if (DateEnd.SelectedDate != null && DateStart.SelectedDate != null)
            {
                var start = (DateTime)DateStart.SelectedDate;
                var end = (DateTime)DateEnd.SelectedDate;
                if (DateEnd.SelectedDate < DateStart.SelectedDate)
                {

                    DateEnd.SelectedDate = start.AddDays(1);
                    MessageBox.Show("Početni datum mora biti raniji od krajnjeg datuma.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (ReportChoiceComboBox.SelectedItem != null && ReportChoiceComboBox.SelectedItem.ToString().Split(':')[1].Substring(1).ToLower() == "dnevni")
                {

                    if (end - start > TimeSpan.FromDays(60))
                    {
                        DateEnd.SelectedDate = start.AddDays(60);
                        MessageBox.Show("Dnevni izveštaj može prikazivati podatke u vremenskom periodu od najviše 60 dana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else if (ReportChoiceComboBox.SelectedItem != null && ReportChoiceComboBox.SelectedItem.ToString().Split(':')[1].Substring(1).ToLower() == "nedeljni")
                {

                    if (end - start > TimeSpan.FromDays(120))
                    {
                        DateEnd.SelectedDate = start.AddDays(120);
                        MessageBox.Show("Nedeljni izveštaj može prikazivati podatke u vremenskom periodu od najviše 120 dana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else if (ReportChoiceComboBox.SelectedItem != null && ReportChoiceComboBox.SelectedItem.ToString().Split(':')[1].Substring(1).ToLower() == "mesečni")
                {

                    if (end - start > TimeSpan.FromDays(180))
                    {
                        DateEnd.SelectedDate = start.AddDays(180);
                        MessageBox.Show("Mesečni izveštaj može prikazivati podatke u vremenskom periodu od najviše 180 dana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }

            }
        }

        private void DateEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            checkRangeChangeStartDate();

        }

        private void checkRangeChangeStartDate()
        {
            if (DateEnd.SelectedDate != null && DateStart.SelectedDate != null)
            {
                var start = (DateTime)DateStart.SelectedDate;
                var end = (DateTime)DateEnd.SelectedDate;
                if (DateEnd.SelectedDate < DateStart.SelectedDate)
                {
                    DateStart.SelectedDate = end.AddDays(-1);
                    MessageBox.Show("Početni datum mora biti raniji od krajnjeg datuma.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (ReportChoiceComboBox.SelectedItem != null && ReportChoiceComboBox.SelectedItem.ToString().Split(':')[1].Substring(1).ToLower() == "nedeljni")
                {

                    if (end - start > TimeSpan.FromDays(120))
                    {
                        DateStart.SelectedDate = end.AddDays(-120);
                        MessageBox.Show("Nedeljni izveštaj može prikazivati podatke u vremenskom periodu od najviše 120 dana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else if (ReportChoiceComboBox.SelectedItem != null && ReportChoiceComboBox.SelectedItem.ToString().Split(':')[1].Substring(1).ToLower() == "dnevni")
                {

                    if (end - start > TimeSpan.FromDays(60))
                    {
                        DateStart.SelectedDate = end.AddDays(-60);
                        MessageBox.Show("Dnevni izveštaj može prikazivati podatke u vremenskom periodu od najviše 60 dana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }

                else if (ReportChoiceComboBox.SelectedItem != null && ReportChoiceComboBox.SelectedItem.ToString().Split(':')[1].Substring(1).ToLower() == "mesečni")
                {

                    if (end - start > TimeSpan.FromDays(180))
                    {
                        DateStart.SelectedDate = end.AddDays(-180);
                        MessageBox.Show("Mesečni izveštaj može prikazivati podatke u vremenskom periodu od najviše 180 dana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
            }
        }

        private void AppWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (AppWindow.ActualHeight > 550)
            {
                PickArea.Height = new System.Windows.GridLength(150);           
            }
          
        }

        private void ReportChoiceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkRangeChangeEndDate();
        }
    }
}
