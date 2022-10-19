using System.ComponentModel.DataAnnotations;

namespace ModelsLayer;

public class WeatherForecast
{
    public DateTime Date { get; set; } // this is a property.

    [Range(2, 100, ErrorMessage = "Dude, that's really hawt.")]
    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}