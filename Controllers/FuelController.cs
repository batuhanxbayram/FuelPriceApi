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
        public async Task<IActionResult> Get()
        {
            var data = parser.ParseWebAsync("https://www.petrolofisi.com.tr/akaryakit-fiyatlari/istanbul-akaryakit-fiyatlari");


            return Ok(data);
        }




    }
}
