using MiniProject;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

public class DataManager
{
    private static readonly string apiKey = "VWY979IKAYWIHUJP";
    public DataManager() { }

    public static List<Data> FetchTreasury(string interval, string fromDate, string toDate)
    {
        string QUERY_URL = "https://www.alphavantage.co/query?function=TREASURY_YIELD&interval=" + interval.ToLower() + "&maturity=10year&apikey=" + apiKey;
        return filter(Fetch(QUERY_URL), fromDate, toDate);
    }
    public static List<Data> filter(EconomicIndicatorsData data, string fromDate, string toDate)
    {
        return data.Data;
    }
    public static List<Data> FetchGDP(string interval, string fromDate, string toDate)
    {
        string QUERY_URL = "https://www.alphavantage.co/query?function=REAL_GDP" + "&interval=" + interval.ToLower() + "&apikey=" + apiKey;
        return filter(Fetch(QUERY_URL), fromDate, toDate);
    }
    public static EconomicIndicatorsData Fetch(string QUERY_URL)
    {
        Uri queryUri = new Uri(QUERY_URL);

        using (WebClient client = new WebClient())
        {
            EconomicIndicatorsData? json_data = JsonSerializer.Deserialize<EconomicIndicatorsData>(client.DownloadString(queryUri));
            Console.WriteLine(json_data);
            return json_data;
        }
    }
}