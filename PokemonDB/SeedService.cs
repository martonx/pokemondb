using Microsoft.EntityFrameworkCore;
using PokemonDB.ApiModels;
using PokemonDB.DbModels;
using System.Net.Http.Json;

namespace PokemonDB;

public class SeedService(PokemonDbContext dbContext)
{
    public async Task InitDbDataAsync()
    {
        var apiResponse = await new HttpClient().GetFromJsonAsync<ListAPIModel>("https://pokeapi.co/api/v2/pokemon?limit=5");

        foreach (var item in apiResponse.results)
        {
            var pokemonApiDetails = await new HttpClient().GetFromJsonAsync<PokemonAPIModel>(
                $"https://pokeapi.co/api/v2/pokemon/{item.name}");
            Console.WriteLine($"Pokemon name: {pokemonApiDetails.name}");

            var pokemonDbModel = new PokemonDBModel
            {
                HitPoint = pokemonApiDetails.stats.Single(s => s.stat.name == "hp").base_stat,
                Attack = pokemonApiDetails.stats.Single(s => s.stat.name == "attack").base_stat,
                Defense = pokemonApiDetails.stats.Single(s => s.stat.name == "defense").base_stat,
                Name = pokemonApiDetails.name,
            };

            var categories = pokemonApiDetails.types.Select(t => t.type.name);
            foreach (var categoryFromApi in categories)
            {
                var categoryDbModel = await dbContext.Categories.SingleOrDefaultAsync(c => c.Name == categoryFromApi);
                if (categoryDbModel is null)
                {
                    categoryDbModel = new CategoryDBModel
                    {
                        Name = categoryFromApi
                    };

                    dbContext.Categories.Add(categoryDbModel);
                }

                var pokemonCategoryDbModel = new PokemonCategoryDBModel
                {
                    Category = categoryDbModel,
                    Pokemon = pokemonDbModel,
                };

                dbContext.PokemonCategories.Add(pokemonCategoryDbModel);
            }

            dbContext.Pokemons.Add(pokemonDbModel);

            await dbContext.SaveChangesAsync();
        }
    }
}
