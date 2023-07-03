using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Utils;

namespace TI_NET_2023_HeroesVsMonsters.Models.Characters.Monsters
{
    public abstract class Monster : Character
    {
        protected Monster(string sprite) : base(sprite)
        {
            Stats.Generate();
        }

        public override void Attack(Character target)
        {
            int dmg = (Inteligence - target.Resistance <= 0 ? 1 : Inteligence - target.Resistance) + Dice.Throw();
            target.TakeDamage(dmg);
            base.Attack(target);
        }
    }
}
