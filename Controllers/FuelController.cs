using FuelPriceApi.Parser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FuelPriceApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
       
        FuelParser parser = new FuelParser();
      

        [HttpGet]
        public async Task<IActionResult> GetIstanbul()
        {
            var data = parser.ParseWebAsync("https://www.petrolofisi.com.tr/akaryakit-fiyatlari/istanbul-akaryakit-fiyatlari");
           
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAnkara()
        {
            var data = parser.ParseWebAsync("https://www.petrolofisi.com.tr/akaryakit-fiyatlari/ankara-akaryakit-fiyatlari");

            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetIzmir()
        {
            var data = parser.ParseWebAsync("https://www.petrolofisi.com.tr/akaryakit-fiyatlari/izmir-akaryakit-fiyatlari");

            return Ok(data);
        }




    }
}
