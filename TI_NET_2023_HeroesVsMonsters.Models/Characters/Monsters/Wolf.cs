using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics;
using TI_NET_2023_HeroesVsMonsters.Utils;

namespace TI_NET_2023_HeroesVsMonsters.Models.Characters.Monsters
{
    public class Wolf : Monster
    {
        public Wolf() : base("🐺")
        {
            Stats.Append(StatType.Strength, 5);
            Stats.Append(StatType.Speed, 5);
            FullRegen();
        }
    }
}
