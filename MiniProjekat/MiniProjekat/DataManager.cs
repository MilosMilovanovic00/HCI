using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;
using System.ComponentModel;

namespace MiniProjekat
{
    public class DataManager
    {
        public enum GDCInterval
        {
            [Description("Godisnji")]
            annaul,
            quarterly
        }
        public enum TreasuryInterval
        {
            daily,
            weekly,
            monthly
        }

        private static readonly string apiKey = "VWY979IKAYWIHUJP";
        public DataManager() { }

        public static List<Data> FetchTreasury(string interval, string fromDate, string toDate)
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=TREASURY_YIELD&interval=" + interval.ToLower() + "&maturity=10year&apikey=" + apiKey;
            
            return filter(Fetch(QUERY_URL), fromDate, toDate);
        }
        public static List<Data> filter(EconomicIndicatorsData economicIndicatorsData, string fromDate, string toDate)
        {
            List<Data> filteredList = new List<Data>();
            return economicIndicatorsData.Data.Where(x => x.InRange(fromDate, toDate)).ToList();
        }
        public static List<Data> FetchGDP(string interval, string fromDate, string toDate)
        {
            string QUERY_URL = "https://www.alphavantage.co/query?function=REAL_GDP" + "&interval=" + interval.ToLower() + "&apikey=" + apiKey;
            return filter(Fetch(QUERY_URL), fromDate, toDate);
        }
        private static EconomicIndicatorsData Fetch(string QUERY_URL)
        {
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                EconomicIndicatorsData data =(EconomicIndicatorsData)js.Deserialize(client.DownloadString(queryUri), typeof(EconomicIndicatorsData));
               
                return data;
            }
        }
    }
}
