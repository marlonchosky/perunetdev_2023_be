using BuscadorDeStreamings.WebApi.Entidades;
using TMDbLib.Objects.Movies;

namespace BuscadorDeStreamings.WebApi.Entidades {
    public class PeliculaBuilder {
        private IReadOnlyList<Comprador> _compradores = new List<Comprador>();
        private IReadOnlyList<ProveedoresDeStreaming> _proveedoresDeStreaming = new List<ProveedoresDeStreaming>();
        private Pelicula.DatosGeneralesClass _datosGenerales = Pelicula.DatosGeneralesClass.SinEspecificar();

        public Pelicula Build() {
            var pelicula = new Pelicula();
            _compradores.ToList().ForEach(comprador => pelicula.AgregarComprador(comprador.Nombre, comprador.LogoUrl));
            _proveedoresDeStreaming.ToList().ForEach(proveedor => pelicula.AgregarProveedorDeStreaming(proveedor.Nombre, proveedor.LogoUrl));

            if (!_datosGenerales.EsSinEspecificar())
                pelicula.AgregarDatosGenerales(this._datosGenerales);

            return pelicula;
        }

        internal PeliculaBuilder AgregarDondeComprar(IReadOnlyList<Comprador> compradores) {
            _compradores = compradores;
            return this;
        }

        internal PeliculaBuilder AgregarDondeVerEnStreaming(IReadOnlyList<ProveedoresDeStreaming> proveedoresDeStreaming) {
            _proveedoresDeStreaming = proveedoresDeStreaming;
            return this;
        }

        internal void AgregarParametrosGenerales(Movie movie) =>
            _datosGenerales = new Pelicula.DatosGeneralesClass {
                Resumen = movie.Overview,
                PaginaDeInicio = movie.Homepage,
                Titulo = movie.OriginalTitle,
                IdiomaOriginal = movie.OriginalLanguage,
                TagLine = movie.Tagline,
                RutaDelPoster = movie.PosterPath,
                RutaDelPosterDeFondo = movie.BackdropPath,
                FechaDeEstreno = movie.ReleaseDate?.ToString("yyyy-MM-dd")
            };
    }
}