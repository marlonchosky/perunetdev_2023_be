namespace BuscadorDeStreamings.WebApi.Entidades {
    public class PeliculaBuilder {
        private IReadOnlyList<string> _compradores = new List<string>();
        private IReadOnlyList<string> _proveedoresDeStreaming = new List<string>();

        public Pelicula Build() {
            var pelicula = new Pelicula();
            _compradores.ToList().ForEach(pelicula.AgregarComprador);
            _proveedoresDeStreaming.ToList().ForEach(pelicula.AgregarProveedorDeStreaming);

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
    }
}