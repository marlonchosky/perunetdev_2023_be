namespace BuscadorDeStreamings.WebApi.Entidades {
    public class DetalleGeneralDePelicula {
        public DetalleGeneralDePelicula(int id, string titulo) {
            Id = id;
            Titulo = titulo;
        }

        public int Id { get; }
        public string Titulo { get; }
    }
}