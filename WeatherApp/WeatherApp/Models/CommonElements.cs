using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    // Classes, commin for both of models

    public class Main
    {
        public double Temp { private get; set; }
        public double Temp_min { private get; set; }
        public double Temp_max { private get; set; }

        public string Temperature
        {
            get { return $"{Temp.ToString()} \u00B0C"; }
        }
        public string MinTemp
        {
            get { return $"{Temp_min.ToString()} \u00B0C"; }
        }
        public string MaxTemp
        {
            get { return $"{Temp_max.ToString()} \u00B0C"; }
        }

    }
    public class Clouds
    {
        public double All { private get; set; }
        public string Cloudiness
        {
            get { return $"{All.ToString()} %"; }
        }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Wind
    {
        public double Speed { private get; set; }
        public string WindSpeed
        {
            get { return $"{Speed.ToString()} m/s"; }
        }

    }

}