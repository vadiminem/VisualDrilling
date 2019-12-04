using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    public class TestController : ControllerBase
    {
        [EnableCors]
        [HttpGet]
        public IActionResult GetCoords()
        {
            var coords = new double[]
        {
                0.0, 0.4, 0.0,
                0.1, -0.2, 0.0,
                0.125, -0.25, 0.0,
                0.15, -0.249, 0.0,
                0.22, -0.19, 0.0
        };
            
            return Ok(coords);
        }

    }
}