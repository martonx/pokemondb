using Microsoft.EntityFrameworkCore;

using PokemonDB.DbModels;

namespace PokemonDB;

public class FightService(PokemonDbContext db)
{
    public async Task CreateAsync()
    {
        Console.WriteLine("Kérem válasszon támadót (Id)");

        foreach (var pokemon in db.Pokemons)
            Console.WriteLine($"Id: {pokemon.Id} Név: {pokemon.Name}, Hitpoint: {pokemon.HitPoint}");

        var attackerId = int.Parse(Console.ReadLine());

        Console.WriteLine("Kérem válasszon védőt (Id)");

        foreach (var pokemon in db.Pokemons)
            Console.WriteLine($"Id: {pokemon.Id} Név: {pokemon.Name}, Hitpoint: {pokemon.HitPoint}");

        var defenderId = int.Parse(Console.ReadLine());

        var fight = new FightDbModel
        {
            AttackerId = attackerId,
            DefenderId = defenderId,
            Date = DateTime.Now,
        };

        db.Fights.Add(fight);

        var attacker = await db.Pokemons.SingleAsync(p => p.Id == attackerId);
        var defender = await db.Pokemons.SingleAsync(p => p.Id == defenderId);
        var currentHitpoint = defender.HitPoint - attacker.Attack;

        for (var i = 0; i < 3; i++)
        {
            Console.WriteLine($"{i}. csapás:");
            var isKilled = currentHitpoint < 1;
            var fightItem = new FightItemDbModel
            {
                Attack = attacker.Attack,
                Defense = defender.Defense,
                DefenderHitpoint = currentHitpoint,
                Fight = fight,
                IsKilled = isKilled
            };
            db.FightItems.Add(fightItem);
            Console.WriteLine($"Eredménye: CurrentHitpoint: {fightItem.DefenderHitpoint}");

            if (isKilled)
                break;

            currentHitpoint = currentHitpoint - attacker.Attack;
        }

        await db.SaveChangesAsync();
    }
}
