using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics;
using TI_NET_2023_HeroesVsMonsters.Utils;

namespace TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes
{
    public class Mage : Hero
    {
        public Mage(string name) : base("🧙‍♂️", name)
        {
            Stats.Append(StatType.Inteligence, 5);
            Stats.Append(StatType.Resistance, 5);
            Stats.Append(StatType.Mp, 10);
            FullRegen();
        }
    }
}
