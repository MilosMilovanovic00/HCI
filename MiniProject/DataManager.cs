using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

public class DataManager
{
    private string readonly apiKey = "VWY979IKAYWIHUJP";
    public DataManager() { }

    public String fetchGDP(string function, string interval)
    {
        Console.WriteLine(apiKey);
        string QUERY_URL = "https://www.alphavantage.co/query?function=" + function + "&interval=" + interval + "&apikey=" + apiKey;
        Uri queryUri = new Uri(QUERY_URL);

        using (WebClient client = new WebClient())
        {
            // -------------------------------------------------------------------------
            // if using .NET Framework (System.Web.Script.Serialization)

            JavaScriptSerializer js = new JavaScriptSerializer();
            dynamic json_data = js.Deserialize(client.DownloadString(queryUri), typeof(object));

            // -------------------------------------------------------------------------
            // if using .NET Core (System.Text.Json)
            // using .NET Core libraries to parse JSON is more complicated. For an informative blog post
            // https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-apis/

            dynamic json_data = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(client.DownloadString(queryUri));

            // -------------------------------------------------------------------------

            // do something with the json_data
        }
	}
}