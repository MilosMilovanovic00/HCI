using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject
{
    public class EconomicIndicatorsData
    {
        public string Name { get; set; }
        public string Interval { get; set; }
        public string Unit { get; set; }
        public List<Data> Data { get; set; }

        public EconomicIndicatorsData() { }
    }
}
