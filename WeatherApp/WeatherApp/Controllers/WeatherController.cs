using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherWebApp.Models;

namespace WeatherApp.Controllers
{
    /// <summary>
    /// Contains methods for getting a weather forecast
    /// </summary>
    public class WeatherController : ApiController
    {
        // appid that allows access to openweathermap
        const string APPID = "2814456a2a8345268512a93de178b0d1";

        /// <summary>
        /// Getting the current weather
        /// </summary>
        /// <param name="city">Сity for which the weather will be taken</param>
        /// <returns>Json object with currnet weather </returns>
        [HttpGet]
        [Route("api/GetCurrentWeather/")]
        public IHttpActionResult GetCurrentWeather(string city)

        {
            if (city == null)
            {
                return BadRequest("Сity is not specified");
            }
            else
            {
                CurrentWeather.Root outResult = new CurrentWeather.Root(); // Object for storage Deserialize json object
                using (WebClient web = new WebClient()) // Try to getting data from resource
                {
                    try
                    {
                        outResult = JsonConvert.DeserializeObject<CurrentWeather.Root>(
                            web.DownloadString($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={APPID}&units=metric"));
                    }
                    catch (WebException wex) // Handle several web exception, and send exception message
                    {
                        IHttpActionResult response;
                        HttpWebResponse responseEx = (HttpWebResponse)wex.Response;
                        HttpResponseMessage responseMsg = Request.CreateErrorResponse(responseEx.StatusCode, wex.Message);
                        response = ResponseMessage(responseMsg);
                        return response;
                    }
                    catch (Exception ex) // Handle rest of exception
                    {
                        InternalServerError(ex);
                    }
                }
                return Ok(outResult);
            }
        }

        /// <summary>
        /// Getting the Forecast
        /// </summary>
        /// <param name="city">Сity for which the weather will be taken</param>
        /// <returns>Json object with 5 day / 3 hour forecast data </returns>
        [HttpGet]
        [Route("api/GetForecast/")]
        public IHttpActionResult GetForecast(string city)
        {
            if (city == null)
            {
                return BadRequest("Сity is not specified");
            }
            else
            {
                Forecast outResult = new Forecast(); // Object for storage Deserialize json object
                using (WebClient web = new WebClient()) // Try to getting data from resource
                {
                    try
                    {
                        outResult = JsonConvert.DeserializeObject<Forecast>(
                            web.DownloadString($"http://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&appid={APPID}"));
                    }
                    catch (WebException wex) // Handle several web exception, and send exception message
                    {
                        IHttpActionResult response;
                        HttpWebResponse responseEx = (HttpWebResponse)wex.Response;
                        HttpResponseMessage responseMsg = Request.CreateErrorResponse(responseEx.StatusCode, wex.Message);
                        response = ResponseMessage(responseMsg);
                        return response;
                    }
                    catch (Exception ex) // Handle rest of exception
                    {
                        InternalServerError(ex);
                    }
                }
                return Ok(outResult);
            }
        }
    }
}
