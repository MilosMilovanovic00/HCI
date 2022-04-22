using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MiniProjekat
{
    /// <summary>
    /// Interaction logic for TableInfo.xaml
    /// </summary>
    public partial class TableInfo : Window
    {
        public List<Data> TableData { get; set; }
        public string MaxValue { get; set; }
        public string MinValue { get; set; }
        public TableInfo(List<Data> data)
        {
            this.DataContext = this;
            TableData = data;
            MaxValue = data.Max(d => d.Value);
            MinValue = data.Min(d => d.Value);
            InitializeComponent();

            if (data.Count > 1)
            {
                var st = new Style();
                st.TargetType = typeof(DataGridRow);
                var AliceBlueSetter = new Setter(DataGridRow.BackgroundProperty, Brushes.LightGreen);
                var RedSetter = new Setter(DataGridRow.BackgroundProperty, Brushes.LightPink);

                var dt1 = new DataTrigger()
                {
                    Value = MaxValue,
                    Binding = new Binding("Value")
                };
                var dt2 = new DataTrigger()
                {
                    Value = MinValue,
                    Binding = new Binding("Value")
                };
                dt1.Setters.Add(AliceBlueSetter);
                st.Triggers.Add(dt1);

                dt2.Setters.Add(RedSetter);
                st.Triggers.Add(dt2);

                TableDataGrid.RowStyle = st;
            }
        }
    }
}
