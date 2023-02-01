namespace BuscadorDeStreamings.WebApi {
    public class InformacionDePeliculaService {
        public async Task<Resultado> Consultar(FiltroDeInformacionDePelicula filtro) {
            var resultado = new Resultado(filtro);
            resultado.AgregarPelicula(new DetalleGeneralDePelicula(id: 1, titulo: "Titulo"));

            await Task.Delay(1_000);
            return resultado;
        }
    }

    internal class DetalleGeneralDePelicula {
        public DetalleGeneralDePelicula(int id, string titulo) {
            this.Id = id;
            this.Titulo = titulo;
        }

        public int Id { get; }
        public string Titulo { get; }
    }

    public class Resultado {
        private readonly FiltroDeInformacionDePelicula _filtro;
        private readonly List<DetalleGeneralDePelicula> _listaDeDetalles;

        public Resultado(FiltroDeInformacionDePelicula filtro) {
            this._filtro = filtro;
            this._listaDeDetalles = new List<DetalleGeneralDePelicula>();
        }

        internal void AgregarPelicula(DetalleGeneralDePelicula detalle) => 
            this._listaDeDetalles.Add(detalle);
    }

    public record FiltroDeInformacionDePelicula(string? Titulo) { }
    //public record Resultado(int id, string Titulo) { }
}