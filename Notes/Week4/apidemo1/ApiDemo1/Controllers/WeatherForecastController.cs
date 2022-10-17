using Microsoft.AspNetCore.Mvc;

namespace ApiDemo1.Controllers;

[ApiController]
[Route("[controller]")] // "https://www.localhost:4778/weatherforecast/register"
public class WeatherForecastController : ControllerBase
{
    // an array of weather descriptions.
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"// 10 values
    };

    //built in logger.
    private readonly ILogger<WeatherForecastController> _logger;

    // class constructor
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    //the one method in thew api right now.
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),// get a data based off the index (1-5)
            TemperatureC = Random.Shared.Next(-20, 55),// get a randm number between -20 and 55
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    // build a new POST action method that will send back what you send it.
    [HttpPost("mynumdoubled/{myint}")]
    public ActionResult<int> sendbacknum(int myint)
    {
        //call a business layer method that will do the business logic on the data.
        if (myint < 5)
        {
            return Created("marks/created/thing", myint * 2);
        }
        else
        {
            return Unauthorized(new { mark = "markisthe instructor", age = 43 });
        }
    }
}
