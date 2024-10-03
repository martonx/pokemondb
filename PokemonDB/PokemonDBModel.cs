using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PokemonDBModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int HitPoint { get; set; }
    public List<PokemonCategoryDBModel> Categories { get; set; }
}
