using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace ApiDemo1.Controllers;

// The controller is the entrypoint of your .NET API
[ApiController]
[Route("[controller]")] // "https://www.localhost:4778/weatherforecast/register"
public class WeatherForecastController : ControllerBase // Controllerbase is the API base class
{
    // an array of weather descriptions.
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"// 10 values
    };

    //built in logger.
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly Class1 _class1;
    // class constructor
    public WeatherForecastController(ILogger<WeatherForecastController> logger, Class1 c1)
    {
        _logger = logger;
        _class1 = c1;
    }

    //the one method in thew api right now.
    //http://localhost:5000/weatherforecast/GetWeatherForecast
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
    // weatherforecast/mynumdoubled/2?anotherInt=3&
    [HttpPost("mynumdoubled/{myint}")]
    public ActionResult<int> sendbacknum(int myint = -1)
    {
        //call a business layer method that will do the business logic on the data.
        if (myint < 5)
        {
            return Created($"{myint}/marks/created/thing", myint * 2);
        }
        else
        {
            return Unauthorized(new { mark = "mark is the instructor", age = 43 });
        }
    }


    [HttpGet("mystring/{mystring}")]
    public ActionResult<int> sendbacknum1(string mystring = "")
    {
        if (mystring == "q")
        {
            return Ok(10);
        }
        else
        {
            return Unauthorized(new { mark = $"{mystring} is the instructor", age = 43 });
        }
    }

    [HttpPost("new")]
    public ActionResult<WeatherForecast> PostNewForecast(WeatherForecast w)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem("in controller got an error!");
        }
        w.Summary = "You can't get the weather!";
        return Ok(w);
    }
}
