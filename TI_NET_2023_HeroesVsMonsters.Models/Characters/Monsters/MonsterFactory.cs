using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes;
using TI_NET_2023_HeroesVsMonsters.Utils;

namespace TI_NET_2023_HeroesVsMonsters.Models.Characters.Monsters
{
    public static class MonsterFactory
    {
        public static Monster GenerateMonster()
        {
            Monster monster;
            switch (Dice.Throw())
            {
                case 1:
                case 2:
                case 3:
                    return new Wolf();
                case 4:
                case 5:
                    return new Troll();
                case 6:
                    return new Dragon();
                default:
                    throw new Exception();
            }
        }

        
    }
}
