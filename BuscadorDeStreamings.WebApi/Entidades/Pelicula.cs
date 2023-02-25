namespace BuscadorDeStreamings.WebApi.Entidades
{
    public class Pelicula {
        private readonly List<Comprador> _compradores = new();
        private readonly List<ProveedoresDeStreaming> _proveedoresDeStreaming = new();

        public IReadOnlyList<Comprador> Compradores => _compradores;
        public IReadOnlyList<ProveedoresDeStreaming> ProveedoresDeStreaming => _proveedoresDeStreaming;
        public DatosGeneralesClass DatosGenerales { get; set; } = DatosGeneralesClass.SinEspecificar();

        internal Pelicula() { }

        internal void AgregarComprador(string nombreDeComprador, string logoComprador) => _compradores.Add(new Comprador { Nombre = nombreDeComprador, LogoUrl = logoComprador });
        internal void AgregarProveedorDeStreaming(string nombreDelProveedorDeStreaming, string logoProveedorDeStreaming) => _proveedoresDeStreaming.Add(new ProveedoresDeStreaming { Nombre = nombreDelProveedorDeStreaming, LogoUrl = logoProveedorDeStreaming });
        internal void AgregarDatosGenerales(DatosGeneralesClass datosGenerales) => this.DatosGenerales = datosGenerales;

        public class DatosGeneralesClass {
            public string? Resumen { get; init; }
            public string? PaginaDeInicio { get; init; }
            public string? Titulo { get; init; }
            public string? IdiomaOriginal { get; init; }
            public string? TagLine { get; init; }
            public string? RutaDelPoster { get; init; }
            public string? RutaDelPosterDeFondo { get; init; }
            public string? FechaDeEstreno { get; init; }

            public bool EsSinEspecificar() => this.Titulo == string.Empty;
            public static DatosGeneralesClass SinEspecificar() => new() { Titulo = string.Empty };
        }
    }

    public class Comprador {
        public string? Nombre { get; init; }
        public string? LogoUrl { get; init; }
    }

    public class ProveedoresDeStreaming {
        public string? Nombre { get; init; }
        public string? LogoUrl { get; init; }
    }
}