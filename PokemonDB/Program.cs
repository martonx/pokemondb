using System.Net.Http.Json;
using PokemonDB;

var db = new PokemonDbContext();

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
        break;
    case MenuOptions.Fight:
        break;
    case MenuOptions.Report:
        break;
    default:
        break;
}
