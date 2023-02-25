using BuscadorDeStreamings.WebApi.Entidades;
using BuscadorDeStreamings.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

builder.Services.AddSingleton<DatosGeneralesDePeliculaService>();
builder.Services.AddSingleton<DatosDePeliculaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/BuscarContenido", async ([FromServices] DatosGeneralesDePeliculaService servicio, string? titulo) => {
    var filtro = new FiltroDeInformacionDePelicula(titulo);
    var resultado = await servicio.Consultar(filtro);
    return resultado;
})
.WithName("BuscarContenido")
.WithOpenApi();

// https://www.themoviedb.org/movie/808-shrek/watch
app.MapGet("/VerDetalleDePelicula", async ([FromServices] DatosDePeliculaService servicio, int id, string codigoDelPais) => {
    var pelicula = await servicio.Obtener(id, codigoDelPais);
    return pelicula;
})
.WithName("VerDetalleDePelicula")
.WithOpenApi();


app.UseCors();

app.Run();
