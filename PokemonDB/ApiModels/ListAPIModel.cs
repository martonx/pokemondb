using PokemonDB.ApiModels;

namespace PokemonDB.ApiModels;

public class ListAPIModel
{
    public int count { get; set; }
    public string next { get; set; }
    public object previous { get; set; }
    public ListAPIResult[] results { get; set; }
}

