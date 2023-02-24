using TMDbLib.Objects.Movies;

namespace BuscadorDeStreamings.WebApi.Entidades {
    public class PeliculaBuilder {
        private IReadOnlyList<string> _compradores = new List<string>();
        private IReadOnlyList<string> _proveedoresDeStreaming = new List<string>();
        private Pelicula.DatosGeneralesClass _datosGenerales = Pelicula.DatosGeneralesClass.SinEspecificar();

        public Pelicula Build() {
            var pelicula = new Pelicula();
            _compradores.ToList().ForEach(pelicula.AgregarComprador);
            _proveedoresDeStreaming.ToList().ForEach(pelicula.AgregarProveedorDeStreaming);

            if (!_datosGenerales.EsSinEspecificar())
                pelicula.AgregarDatosGenerales(this._datosGenerales);

            return pelicula;
        }

        internal PeliculaBuilder AgregarDondeComprar(IReadOnlyList<string> compradores) {
            _compradores = compradores;
            return this;
        }

        internal PeliculaBuilder AgregarDondeVerEnStreaming(IReadOnlyList<string> proveedoresDeStreaming) {
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
            };
    }
}