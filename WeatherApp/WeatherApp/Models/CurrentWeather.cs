using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models;

namespace WeatherWebApp.Models
{
    /// <summary>
    /// Model for current weather json object
    /// </summary>
    public class CurrentWeather
    {
        /// <summary>
        /// Root of current weather json object
        /// </summary>
        public class Root
        {
            public Main Main { get; set; }
            public string Name { get; set; }

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
            public Wind Wind { get; set; }
            public Clouds Clouds { get; set; }
            public List<Weather> Weather { get; set; }
        }
    }
}