namespace BuscadorDeStreamings.WebApi.Entidades {
    public class Pelicula {
        private readonly List<string> _compradores = new();
        private readonly List<string> _proveedoresDeStreaming = new();

        public IReadOnlyList<string> Compradores => _compradores;
        public IReadOnlyList<string> ProveedoresDeStreaming => _proveedoresDeStreaming;
        public DatosGeneralesClass DatosGenerales { get; set; } = DatosGeneralesClass.SinEspecificar();

        internal Pelicula() { }

        internal void AgregarComprador(string nombreDeComprador) => _compradores.Add(nombreDeComprador);
        internal void AgregarProveedorDeStreaming(string nombreDelProveedorDeStreaming) => _proveedoresDeStreaming.Add(nombreDelProveedorDeStreaming);
        internal void AgregarDatosGenerales(DatosGeneralesClass datosGenerales) => this.DatosGenerales = datosGenerales;

        public class DatosGeneralesClass {
            public string? Resumen { get; init; }
            public string? PaginaDeInicio { get; init; }
            public string? Titulo { get; init; }
            public string? IdiomaOriginal { get; init; }
            public string? TagLine { get; init; }
            public string? RutaDelPoster { get; init; }

            public bool EsSinEspecificar() => this.Titulo == string.Empty;
            public static DatosGeneralesClass SinEspecificar() => new() { Titulo = string.Empty };

        }
    }
}