using DatingApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUserRepository _tokenService;
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _tokenService = userRepository;
        }
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {

            var user = new Persistence.DTO.AppUserDTO {
            Username = "SelenaGomezFahad",
            City = "California",
            Country = "United States",
            Interests = "Fahad Sheikh",
            KnownAs = "Selena Fahad",
            Gender = false,
            LookingFor = "Fahad Sheikh",
            Introduction = "Hi, I am Selena Gomez, Fahad Sheikh's wife"
            
            };
            return Ok(
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                
            })
            .ToArray());
        }
    }
}