using BuscadorDeStreamings.WebApi.Entidades;
using TMDbLib.Client;

namespace BuscadorDeStreamings.WebApi.Services {
    public class DatosGeneralesDePeliculaService {
        private const string _apiKey = "9b012b3d9b77f80761c55261d9a43379";

        public async Task<PeliculasQueCumplenConFiltro> Consultar(FiltroDeInformacionDePelicula filtro) {
            if (filtro.Titulo is null)
                throw new ArgumentNullException(nameof(filtro.Titulo));

            var cliente = new TMDbClient(_apiKey);
            var resultadosDeApi = await cliente.SearchMovieAsync(filtro.Titulo);

            var resultado = new PeliculasQueCumplenConFiltro(filtro);

            resultadosDeApi.Results
                .Select(r => new DetalleGeneralDePelicula(r.Id, r.OriginalTitle, r.PosterPath, r.BackdropPath, r.ReleaseDate?.ToString("yyyy-MM-dd"), r.Overview))
                .ToList()
                .ForEach(resultado.AgregarPelicula);

            return resultado;
        }
    }
}