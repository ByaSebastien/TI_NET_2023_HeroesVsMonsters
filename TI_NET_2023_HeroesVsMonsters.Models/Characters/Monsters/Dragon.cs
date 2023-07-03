using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics;

namespace TI_NET_2023_HeroesVsMonsters.Models.Characters.Monsters
{
    public class Dragon : Monster
    {
        public Dragon() : base("🐉")
        {
            Stats.Append(StatType.Hp, 20);
            Stats.Append(StatType.Strength, 10);
            Stats.Append(StatType.Defence, 10);
            Stats.Append(StatType.Mp, 20);
            Stats.Append(StatType.Inteligence, 10);
            Stats.Append(StatType.Resistance, 10);
            FullRegen();
        }
    }
}
