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
using System.Windows.Shapes;

namespace MiniProjekat
{
    /// <summary>
    /// Interaction logic for TableInfo.xaml
    /// </summary>
    public partial class TableInfo : Window
    {
        public List<Data> TableData { get; set; }
        public TableInfo(List<Data> data)
        {
            InitializeComponent();
            this.DataContext = this;
            TableData = data;
        }
    }
}
