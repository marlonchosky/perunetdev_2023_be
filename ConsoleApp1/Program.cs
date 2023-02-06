using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace ConsoleApp1 {
    internal class Program {
        private static async Task Main(string[] args) {
            // https://github.com/LordMike/TMDbLib
            // https://www.themoviedb.org/settings/api
            // https://developers.themoviedb.org/3/getting-started/introduction

            BuscarPeliculaPorTitulo();
            await BuscarProveedoresPorId();
        }

        private static void BuscarPeliculaPorTitulo() {
            var client = new TMDbClient("9b012b3d9b77f80761c55261d9a43379");
            var titulo = "Shrek";
            var results = client.SearchMovieAsync(titulo).Result;

            Console.WriteLine($"Got {results.Results.Count:N0} of {results.TotalResults:N0} results");
            foreach (var result in results.Results) {
                Console.WriteLine($"{result.Id} - {result.OriginalTitle}");

            }
        }

        private static async Task BuscarProveedoresPorId() {
            Console.WriteLine("Buscar proveedores");

            var client = new TMDbClient("9b012b3d9b77f80761c55261d9a43379");
            var movie = await client.GetMovieAsync(808, MovieMethods.WatchProviders);


            Console.WriteLine();
            foreach (var (key, value) in movie.WatchProviders.Results.Where(p => p.Key == "PE")) {
                Console.WriteLine(value.Buy[0].ProviderName);
            }
        }

        private static void Test1() {
            var client = new TMDbClient("9b012b3d9b77f80761c55261d9a43379");
            var movie = client.GetMovieAsync(47964).Result;
            Console.WriteLine($"Movie name: {movie.Title}");
        }

        private static async Task Testing() {
            var client = new HttpClient();
            var request = new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=netflix&type=movie&genre=18&page=1&output_language=en&language=en"),
                Headers =
                {
                    { "X-RapidAPI-Key", "5afe4b95bbmsh98abee152130068p18bfa4jsn3bf700bf4123" },
                    { "X-RapidAPI-Host", "streaming-availability.p.rapidapi.com" },
                },
            };
            var response = await client.SendAsync(request);
            _ = response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
        }
    }
}