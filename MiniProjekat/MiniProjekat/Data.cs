using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjekat
{
    public class Data
    {
        public string Date { get; set; }

        private string _value;
        public string Value { get { return _value; } set { _value = value == "." ? "0.0" : value; } }

        public Data() { }

        public bool InRange(string fromDateStr, string toDateStr)
        {
            DateTime fromDate = DateTime.Parse(fromDateStr); //treba biti u formi yyyy-mm-dd
            DateTime toDate = DateTime.Parse(toDateStr); //treba biti u formi yyyy-mm-dd
            DateTime date = DateTime.Parse(Date);
            return date >= fromDate && date < toDate; ;
        }
    }
}
