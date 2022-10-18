namespace consolehttpclient;

// default privacy level of a class in C# is 'internal'
class Program
{

    private static readonly HttpClient httpclient = new HttpClient();
    static async Task Main(string[] args)
    {
        //use HttpClient in a console app to query our running (locally) api
        httpclient.BaseAddress = new Uri("https://localhost:7083/WeatherForecast/");

        // Console.WriteLine(httpclient.DefaultRequestHeaders.Accept);
        string str1 = "This is a console app";
        string str2 = "q";

        Task<HttpResponseMessage> response = httpclient.GetAsync($"mystring/q");// call an async method to the endpoint




        HttpResponseMessage res1 = await response;// the program execution pauses here waiting of the Task to fulfill
        var res2 = res1.EnsureSuccessStatusCode();
        Console.WriteLine($"The string method returned - {res1.Content.ReadAsStringAsync()}");








    }
}
