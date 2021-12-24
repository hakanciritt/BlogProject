using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Dashboard.Components
{
    public class StatisticViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string apiKey = "75cd4d41e3f23a1e993df9aaef65ee59";
            string cityName = "istanbul";

            string connection =
                $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&mode=xml&appid={apiKey}";
            XDocument document = XDocument.Load(connection);
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value")?.Value;

            return View();
        }
    }
}
