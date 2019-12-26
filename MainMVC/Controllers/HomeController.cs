using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MainMVC.Models;
using BoreholeCalculation;
using System.Net.Http;
using Newtonsoft.Json;

namespace MainMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            using var client = new HttpClient();

            var response = await client.GetAsync("http://localhost:5000/api/Data/Get?id=1");

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var borehole = new Borehole();
                    var data = await response.Content.ReadAsStringAsync();

                    borehole.Points = JsonConvert.DeserializeObject<Borehole>(data).Points;
                    borehole.MCM(borehole.Points);

                    return Ok(borehole.Coordinates);
                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
            }
            return Ok("Неудачный запрос");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
