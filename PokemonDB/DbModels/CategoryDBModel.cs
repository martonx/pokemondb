namespace PokemonDB.DbModels;

public class CategoryDBModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<PokemonCategoryDBModel> Pokemons { get; set; }
}
