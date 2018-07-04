using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models;

namespace WeatherWebApp.Models
{
    /// <summary>
    /// Model for forecast json object
    /// </summary>
    public class Forecast
    {
        public City City { get; set; }
        public List<List> List { get; set; } // список данных прогноза
    }
    public class List
    {
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }

        /// <summary>
        ///  dt storage json dt in millisecounds
        /// </summary>
        /// <value>dt property sets the value of the json dt</value>
        public double Dt
        {
            set; private get;
        }

        /// <summary>
        ///  date property represents json dt in ISO format yyyy-MM-dd hh:mm
        /// </summary>
        /// <value>dt property gets the value of the json dt</value>
        public string Date
        {
            get
            {
                double milliSecounds = Dt;
                DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
                day = day.AddSeconds(milliSecounds).ToLocalTime();
                return day.ToString("yyyy-MM-dd hh:mm");
            }
        }
    }
    public class City
    {
        public string Name { get; set; }
    }
}
