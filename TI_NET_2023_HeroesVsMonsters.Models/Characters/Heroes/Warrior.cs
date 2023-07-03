using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics;
using TI_NET_2023_HeroesVsMonsters.Utils;

namespace TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes
{
    public class Warrior : Hero
    {
        public Warrior(string name) : base("🧑‍🚒",name) 
        {
            if(Name == "Dante")
            {
                Stats.CheatModeOn();
            }
            Stats.Append(StatType.Strength, 5);
            Stats.Append(StatType.Defence, 5);
            Stats.Append(StatType.Hp, 10);
            FullRegen();
        }

        public override void Attack(Character target)
        {
            //int dmg = Stats.Modifier(StatType.Strength) + Dice.Throw();
            int dmg = (Strength - target.Defence <= 0 ? 1 : Strength - target.Defence) + Dice.Throw();
            target.TakeDamage(dmg);
            base.Attack(target);
        }
    }
}
