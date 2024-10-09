namespace PokemonDB.DbModels;

public class FightDbModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public int AttackerId { get; set; }
    public PokemonDBModel Attacker { get; set; }

    public int DefenderId { get; set; }
    public PokemonDBModel Defender { get; set; }

    public List<FightItemDbModel> FightItems { get; set; }
}
