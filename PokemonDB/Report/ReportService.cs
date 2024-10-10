using Microsoft.EntityFrameworkCore;

namespace PokemonDB.Report;

public class ReportService(PokemonDbContext dbContext)
{
    public async Task<List<ReportModel>> GetCategoryAttacksAsync()
    {
        var result = await dbContext.Database.SqlQuery<ReportModel>($"""
            select c.Name as CategoryName, sum(fi.Attack) as AttackSum
            from Pokemons p
            inner join PokemonCategories pc on p.Id = pc.PokemonId
            inner join Categories c on c.Id = pc.CategoryId
            inner join Fights f on f.AttackerId = p.Id
            inner join FightItems fi on fi.FightId = f.Id
            group by c.Name
            """).ToListAsync();

        return result;
    }

    public async Task<ReportModel> BestAttackerCategoryAsync()
    {
        var result = await dbContext.Database.SqlQuery<ReportModel>($"""
            select top 1 c.Name as CategoryName, sum(fi.Attack)  as AttackSum
            from Pokemons p
            inner join PokemonCategories pc on p.Id = pc.PokemonId
            inner join Categories c on c.Id = pc.CategoryId
            inner join Fights f on f.AttackerId = p.Id
            inner join FightItems fi on fi.FightId = f.Id
            group by c.Name
            order by 2 desc
            """).SingleAsync();

        return result;
    }
}
