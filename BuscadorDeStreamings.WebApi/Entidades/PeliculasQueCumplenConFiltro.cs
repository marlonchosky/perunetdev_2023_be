namespace BuscadorDeStreamings.WebApi.Entidades {
    public class PeliculasQueCumplenConFiltro {
        private readonly FiltroDeInformacionDePelicula _filtro;
        private readonly List<DetalleGeneralDePelicula> _listaDeDetalles;

        public PeliculasQueCumplenConFiltro(FiltroDeInformacionDePelicula filtro) {
            _filtro = filtro;
            _listaDeDetalles = new List<DetalleGeneralDePelicula>();
        }

        internal void AgregarPelicula(DetalleGeneralDePelicula detalle) =>
            _listaDeDetalles.Add(detalle);

        public IReadOnlyList<DetalleGeneralDePelicula> DetallesDePeliculas => _listaDeDetalles;
    }
}