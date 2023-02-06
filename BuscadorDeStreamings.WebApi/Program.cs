using BuscadorDeStreamings.WebApi.Entidades;
using BuscadorDeStreamings.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

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

app.Run();

internal class Abc {
    public int NombreDeLaPelicula { get; set; }
    public int UrlDeLaImagen { get; set; }
    public int Disponibilidad { get; set; }

    private class Dispo {
        public int NombreProveedor { get; set; }
        public int Tipo { get; set; } // Comprar,alquilar, 
    }
}
