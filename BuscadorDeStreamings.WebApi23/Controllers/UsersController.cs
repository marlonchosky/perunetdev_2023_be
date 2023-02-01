using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BuscadorDeStreamings.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        [HttpGet]
        public IEnumerable<string> Get() => new string[] { "value1", "value2" };

        [HttpGet("{id}")]
        public string Get(int id) => "value";

        [HttpPost]
        public void Post([FromBody] string value) {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }


public static class WeatherForecastEndpoints
{
	public static void MapWeatherForecastEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/WeatherForecast").WithTags(nameof(WeatherForecast));

        group.MapGet("/", () =>
        {
            return new [] { new WeatherForecast() };
        })
        .WithName("GetAllWeatherForecasts")
        .WithOpenApi();
        
        group.MapGet("/{id}", (int id) =>
        {
            //return new WeatherForecast { ID = id };
        })
        .WithName("GetWeatherForecastById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, WeatherForecast input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateWeatherForecast")
        .WithOpenApi();

        group.MapPost("/", (WeatherForecast model) =>
        {
            //return TypedResults.Created($"/WeatherForecasts/{model.ID}", model);
        })
        .WithName("CreateWeatherForecast")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new WeatherForecast { ID = id });
        })
        .WithName("DeleteWeatherForecast")
        .WithOpenApi();  
    }
}}
