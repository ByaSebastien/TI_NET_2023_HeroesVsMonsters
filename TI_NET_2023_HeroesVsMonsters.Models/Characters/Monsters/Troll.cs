using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics;

namespace TI_NET_2023_HeroesVsMonsters.Models.Characters.Monsters
{
    public class Troll : Monster
    {
        public Troll() : base("🧌")
        {
            Stats.Append(StatType.Hp, 10);
            Stats.Append(StatType.Strength, 5);
            Stats.Append(StatType.Defence, 5);
            FullRegen();
        }
    }
}
