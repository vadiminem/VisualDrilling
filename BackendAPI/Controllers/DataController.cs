using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BackendAPI.Controllers
{
    public class DataController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> InsertAsync()
        {
            using var reader = new StreamReader(Request.Body);
            var well = new WellModel();
            var line = await reader.ReadLineAsync();
            var culture = System.Globalization.CultureInfo.InvariantCulture;

            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (line.Length > 5)
                {
                    var formattedLine = line.Trim().Split('\t');

                    try
                    {
                        well.Points.Add(new DrillingPointModel(double.Parse(formattedLine[0], culture),
                            double.Parse(formattedLine[1], culture),
                            double.Parse(formattedLine[2], culture)));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Возникла ошибка при обработке данных. Подробности:\n {0}", ex.Message);
                    }
                }
            }

            return Ok(well);
        }
    }
}