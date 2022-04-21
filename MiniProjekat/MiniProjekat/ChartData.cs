using LiveCharts;
using System;
using System.Collections.Generic;


namespace MiniProjekat
{
    public class ChartData
    {
        public List<String> labels { get; set; }
        public SeriesCollection lineSeriesCollection { get; set; }
        public SeriesCollection columnSeriesCollection { get; set; }

        public ChartData()
        {
            lineSeriesCollection = new SeriesCollection();
            columnSeriesCollection = new SeriesCollection();
            labels = new List<string>();
        }

        public void reset()
        {
            lineSeriesCollection.Clear();
            columnSeriesCollection.Clear();
            labels.Clear();
        }

        
    }
}
