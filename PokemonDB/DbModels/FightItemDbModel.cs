namespace PokemonDB.DbModels;

public class FightItemDbModel
{
    public int Id { get; set; }
    public int Attack {  get; set; }
    public int Defense { get; set; }
    public int DefenderHitpoint { get; set; }
    public bool IsKilled { get; set; }

    public int FightId { get; set; }
    public FightDbModel Fight { get; set; }
}
