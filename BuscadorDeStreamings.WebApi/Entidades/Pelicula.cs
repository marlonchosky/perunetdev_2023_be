namespace BuscadorDeStreamings.WebApi.Entidades {
    public class Pelicula {
        private readonly List<string> _compradores = new();
        private readonly List<string> _proveedoresDeStreaming = new();

        public IReadOnlyList<string> Compradores => this._compradores;
        public IReadOnlyList<string> ProveedoresDeStreaming => this._proveedoresDeStreaming;

        internal Pelicula() { }

        internal void AgregarComprador(string nombreDeComprador) => _compradores.Add(nombreDeComprador);
        internal void AgregarProveedorDeStreaming(string nombreDelProveedorDeStreaming) => _proveedoresDeStreaming.Add(nombreDelProveedorDeStreaming);
    }
}