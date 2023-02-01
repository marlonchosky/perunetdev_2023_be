using BuscadorDeStreamings.WebApi;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<InformacionDePeliculaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/BuscarContenido", async ([FromServices]InformacionDePeliculaService service, [FromQuery]Filtro opciones) => {
    var objeto = new FiltroDeInformacionDePelicula(opciones.Titulo);
    var abc = await service.Consultar(objeto);
    return opciones.Titulo;
})
.WithName("BuscarContenido")
.WithOpenApi();

app.MapGet("/VerDetalleDePelicula", async ([FromServices]InformacionDePeliculaService service, [FromQuery]Filtro opciones) => {
    var objeto = new FiltroDeInformacionDePelicula(opciones.Titulo);
    var abc = await service.Consultar(objeto);
    return opciones.Titulo;

    // Proveedores de streaming
    // Personajes
})
.WithName("VerDetalleDePelicula")
.WithOpenApi();

app.Run();

internal class Filtro {
    public string? Titulo { get; set; }
}
