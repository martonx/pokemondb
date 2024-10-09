using Microsoft.EntityFrameworkCore;

namespace PokemonDB.DbModels;

[PrimaryKey(nameof(PokemonId), nameof(CategoryId))]
public class PokemonCategoryDBModel
{
    public int PokemonId { get; set; }
    public PokemonDBModel Pokemon { get; set; }
    public int CategoryId { get; set; }
    public CategoryDBModel Category { get; set; }
}
