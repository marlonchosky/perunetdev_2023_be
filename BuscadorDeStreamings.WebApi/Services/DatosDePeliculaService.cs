using BuscadorDeStreamings.WebApi.Entidades;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;

namespace BuscadorDeStreamings.WebApi.Services {
    public class DatosDePeliculaService {
        private const string _apiKey = "9b012b3d9b77f80761c55261d9a43379";

        public async Task<Pelicula?> Obtener(int id, string codigoDelPais) {
            var client = new TMDbClient(_apiKey);
            var movie = await client.GetMovieAsync(id, MovieMethods.WatchProviders);

            if (!movie.WatchProviders.Results.Any(p => p.Key == codigoDelPais))
                return null;

            var datosDePeliculaParaPais = movie.WatchProviders.Results.Single(p => p.Key == codigoDelPais).Value;

            var builder = new PeliculaBuilder();
            builder
                .AgregarDondeComprar(MapearCompradores(datosDePeliculaParaPais))
                .AgregarDondeVerEnStreaming(MapearStreaming(datosDePeliculaParaPais))
                .AgregarParametrosGenerales(movie);
            return builder.Build();
        }

        private IReadOnlyList<Comprador> MapearCompradores(WatchProviders providers) => providers.Buy.Select(m => new Comprador { Nombre = m.ProviderName, LogoUrl = m.LogoPath }).ToList();
        private IReadOnlyList<ProveedoresDeStreaming> MapearStreaming(WatchProviders providers) => providers.FlatRate.Select(m => new ProveedoresDeStreaming {
            Nombre = m.ProviderName,
            LogoUrl = m.LogoPath
        }).ToList();
    }
}