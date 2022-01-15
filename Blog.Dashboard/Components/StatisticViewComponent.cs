﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Blog.Dashboard.Components
{
    public class StatisticViewComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;
        private readonly ICommentService _commentService;

        public StatisticViewComponent(IConfiguration configuration, ICommentService commentService)
        {
            _configuration = configuration;
            _commentService = commentService;
        }
        public IViewComponentResult Invoke()
        {
            string apiKey = _configuration["WeatherApi:ApiKey"];

            string connection = $"https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&appid={apiKey}";
            XDocument document = XDocument.Load(connection);
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value")?.Value;
            ViewBag.commentCount = _commentService.GetAll().Data.Count;

            return View();
        }
    }
}
