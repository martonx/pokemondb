namespace PokemonDB.ApiModels;

public class PokemonAPIModel
{
    public int id { get; set; }
    public string name { get; set; }
    public Stat[] stats { get; set; }
    public Type[] types { get; set; }
}

public class Stat
{
    public int base_stat { get; set; }
    public int effort { get; set; }
    public Stat1 stat { get; set; }
}

public class Stat1
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Type
{
    public int slot { get; set; }
    public Type1 type { get; set; }
}

public class Type1
{
    public string name { get; set; }
    public string url { get; set; }
}
