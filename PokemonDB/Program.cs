using PokemonDB;
using PokemonDB.Report;

var db = new PokemonDbContext();

while (true)
{
    Console.WriteLine("Mit csináljunk? 0 - Kilépés, 1 - Adatbázis inicializálás, 2 - Pokemon lista, 3 - Harc, 4 - Riport");
    var taskString = Console.ReadLine();
    Enum.TryParse<MenuOptions>(taskString, out var task);

    switch (task)
    {
        case MenuOptions.Exit:
            Environment.Exit(0);
            break;
        case MenuOptions.Seed:
            var seedService = new SeedService(db);
            await seedService.InitDbDataAsync();
            break;
        case MenuOptions.List:
            foreach (var pokemon in db.Pokemons)
                Console.WriteLine($"Név: {pokemon.Name}, Hitpoint: {pokemon.HitPoint}");
            break;
        case MenuOptions.Fight:
            var fightService = new FightService(db);
            await fightService.CreateAsync();
            break;
        case MenuOptions.Report:
            var reportService = new ReportService(db);
            var results = await reportService.GetCategoryAttacksAsync();
            foreach (var result in results)
                Console.WriteLine($"Kategória: {result.CategoryName}, össz. támadás: {result.AttackSum}");

            var bestResult = await reportService.BestAttackerCategoryAsync();
            Console.WriteLine($"Legjobb támadó kategória: {bestResult.CategoryName}, össz. támadás: {bestResult.AttackSum}");
            break;
        default:
            break;
    }
}
