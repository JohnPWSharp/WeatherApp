using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using WeatherMonitor.Models;

namespace WeatherMonitor.Controllers
{
    public class HomeController : Controller
    {
        private TelemetryClient insightsClient;

        public HomeController(TelemetryClient insightsClient)
        {
            this.insightsClient = insightsClient;
        }

        public IActionResult Index()
        {
            this.insightsClient.GetMetric("AppVersion").TrackValue(1);
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
