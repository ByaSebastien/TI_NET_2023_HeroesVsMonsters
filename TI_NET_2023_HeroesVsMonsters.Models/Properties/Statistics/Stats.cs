using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Utils;

namespace TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics
{
    public class Stats
    {
        private Dictionary<StatType, int> _stats;

        public Stats()
        {
            _stats = new Dictionary<StatType, int>();
        }

        public int this[StatType stat]
        {
            get => _stats.ContainsKey(stat) ? _stats[stat] : 0;
            set
            {
                if (!_stats.ContainsKey(stat))
                {
                    _stats.Add(stat, 0);
                }
                _stats[stat] = value < 0 ? 0 : value;
            }
        }

        public void Append(StatType stat,int amount)
        {
            if (amount < 0)
            {
                return;
            }
            this[stat] += amount;
        }

        public void Withdraw(StatType stat,int amount)
        {
            if(amount < 0) 
            {
                return;
            }
            this[stat] -= amount;
        }

        public void ApplyModifier()
        {
            foreach (StatType stat in Enum.GetValues<StatType>())
            {
                Append(stat, Modifier(stat));
            }
        }

        public int Modifier(StatType stat)
        {
            int qttStat = this[stat];
            if(qttStat > 15) return 3;
            else if (qttStat > 10) return 2;
            else if (qttStat > 5) return 1;
            return 0;
        }

        public void Generate(DiceType dice = DiceType.D6, int nbThrows = 3, int nbToKeep = 3)
        {
            foreach(StatType stat in Enum.GetValues<StatType>())
            {
                if(stat == StatType.Hp || stat == StatType.Mp)
                {
                    continue;
                }
                this[stat] = Dice.Throws(dice, nbThrows, nbToKeep);
            }
            this[StatType.Hp] = this[StatType.Strength] + this[StatType.Defence];
            this[StatType.Mp] = this[StatType.Inteligence] + this[StatType.Resistance];
            ApplyModifier();
        }

        public void CheatModeOn()
        {
            Generate(DiceType.D100, 10, 5);
        }
    }
}
