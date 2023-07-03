using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics;
using TI_NET_2023_HeroesVsMonsters.Utils;

namespace TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes
{
    public class Thief : Hero
    {
        public Thief(string name) : base("🥷", name)
        {
            Stats.Append(StatType.Strength, 10);
            Stats.Append(StatType.Speed, 10);
            FullRegen();
        }

        public override void Attack(Character target)
        {
            int dmg = (Strength - target.Defence <= 0 ? 1 : Strength - target.Defence) + Dice.Throw();
            target.Attack(target);
            base.Attack(target);
        }
    }
}
