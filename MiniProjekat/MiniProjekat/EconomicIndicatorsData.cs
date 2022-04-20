using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekat
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
