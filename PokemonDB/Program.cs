// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;

Console.WriteLine("Hello, World!");

var apiResponse = await new HttpClient().GetFromJsonAsync<ListAPIModel>("https://pokeapi.co/api/v2/pokemon?limit=5");

foreach (var item in apiResponse.results)
{
    var pokemon = await new HttpClient().GetFromJsonAsync<PokemonAPIModel>($"https://pokeapi.co/api/v2/pokemon/{item.name}");
}
