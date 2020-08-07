using IndicadorInflacionWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IndicadorInflacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            using (var request = new HttpRequestMessage())
            {
                string url = "https://www.banxico.org.mx/SieAPIRest/service/v1/series/SP74665/datos";
                string token = "25855a88d1745a144fad51355e2c77cb512ff2a2989e646de98ad9231c99423f";
                var client = new HttpClient();

                request.Method = new HttpMethod("GET");
                request.RequestUri = new Uri(url, System.UriKind.RelativeOrAbsolute);
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Bmx-Token", token);

                var response = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            }
                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
