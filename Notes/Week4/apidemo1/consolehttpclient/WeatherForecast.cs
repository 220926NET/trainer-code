using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace consolehttpclient
{
    public class WeatherForecast
    {
        public DateTime date { get; set; } // this is a property.

        public int temperatureC { get; set; }

        public int temperatureF => 32 + (int)(temperatureC / 0.5556);

        public string? summary { get; set; }
    }
}