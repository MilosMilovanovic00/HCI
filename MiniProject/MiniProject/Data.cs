using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject
{
    public class Data
    {
        public string Date { get; set; }

        private string _value;
        public string Value { get { return _value; } set { _value = value == "." ? "0.0" : value; } }

        public Data() { }
    }
}
