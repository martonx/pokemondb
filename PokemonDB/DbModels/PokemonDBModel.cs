namespace PokemonDB.DbModels;

public class PokemonDBModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int HitPoint { get; set; }
    public List<PokemonCategoryDBModel> Categories { get; set; }
    public List<FightDbModel> AttackerFights { get; set; }
    public List<FightDbModel> DefenderFights { get; set; }
}
