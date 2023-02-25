namespace BuscadorDeStreamings.WebApi.Entidades {
    public class DetalleGeneralDePelicula {
        public DetalleGeneralDePelicula(
            int id,
            string titulo,
            string? urlImagenPrincipal = null,
            string? urlImagenFondo = null,
            string? fechaDeEstreno = null,
            string resumen = ""
        )
        {
            Id = id;
            Titulo = titulo;
            UrlImagenPrincipal = urlImagenPrincipal;
            UrlImagenFondo = urlImagenFondo;
            FechaDeEstreno = fechaDeEstreno;
            Resumen = resumen;
        }

        public int Id { get; }
        public string Titulo { get; }
        public string? UrlImagenPrincipal { get; }
        public string? UrlImagenFondo { get; }
        public string? FechaDeEstreno { get; }
        public string Resumen { get; }
    }
}