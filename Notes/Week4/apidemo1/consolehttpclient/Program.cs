using System.Text;
using System.Text.Json;

namespace consolehttpclient;

// default privacy level of a class in C# is 'internal'
class Program
{

    private static readonly HttpClient httpclient = new HttpClient();
    static async Task Main(string[] args)
    {
        //use HttpClient in a console app to query our running (locally) api
        httpclient.BaseAddress = new Uri("https://localhost:7083/WeatherForecast");

        // Console.WriteLine(httpclient.DefaultRequestHeaders.Accept);
        string str1 = "This is a console app";
        string str2 = "q";

        Task<HttpResponseMessage> response = httpclient.GetAsync($"/mystring/q");// call an async method to the endpoint
        Console.WriteLine("This is a sentence made while you wait for the task to resolve.");
        HttpResponseMessage res1 = await response;// the program execution pauses here waiting of the Task to fulfill
        //var res2 = res1.EnsureSuccessStatusCode();
        Console.WriteLine($"The string method returned - {await res1.Content.ReadAsStringAsync()}");
        // lets get the weatherforecasts!
        HttpResponseMessage forecastsRaw = await httpclient.GetAsync("");
        string res = await forecastsRaw.Content.ReadAsStringAsync();
        IEnumerable<WeatherForecast> forecasts = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(res)!;
        foreach (WeatherForecast w in forecasts)
        {
            Console.WriteLine($"Date - {w.date} -- TemperatureC - {w.temperatureC} -- TemperatureF - {w.temperatureF} -- Summary - {w.summary}");
        }

        //post to follow.
        StringContent jsonContent = //stringify a json object.
            new StringContent(JsonSerializer.Serialize(
                new WeatherForecast
                {
                    date = DateTime.Now,
                    temperatureC = 32,
                    summary = "you're a super cool guy"
                }
                    ),
            Encoding.UTF8,      // include the encoding (mandatory)
            "application/json"  // tell the server the type of the data
        );

        HttpClient hc = new HttpClient();
        // POST the new entity
        HttpResponseMessage response1 = await hc.PostAsync("https://localhost:7083/WeatherForecast/new", jsonContent);
        Console.WriteLine(response1);

        // HttpResponseMessage postResponse = await taskpostresponse;
        HttpResponseMessage statusCode1 = response1.EnsureSuccessStatusCode();
        //string postResponsecontent = await postResponse.Content.ReadAsStringAsync();
        //Console.WriteLine(postResponsecontent);
        WeatherForecast? newforecast = JsonSerializer.Deserialize<WeatherForecast>(response1.Content.ReadAsStream());
        if (newforecast != null)
        {
            Console.WriteLine($"Date - {newforecast.date} -- TemperatureC - {newforecast.temperatureC} -- TemperatureF - {newforecast.temperatureF} -- Summary - {newforecast.summary}");
        }








    }
}
