using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_NET_2023_HeroesVsMonsters.Utils
{
    public static class Dice
    {
        public static int Throws(DiceType dice = DiceType.D6,int nbThrows = 3,int nbToKeep = 3)
        {
            List<int> throws = new List<int>();
            for (int i = 0; i < nbThrows; i++)
            {
                throws.Add(Throw(dice));
            }
            return throws.OrderByDescending(it => it).Take(nbToKeep).Sum();
        }

        public static int Throw(DiceType dice = DiceType.D6)
        {
            Random rnd = new Random();
            return rnd.Next((int)dice) + 1;
        }
    }
}
