using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Equipments;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics;

namespace TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes
{
    public abstract class Hero : Character
    {
        public string Name { get; set; }
        public Equipements Equipements { get; set; }

        public Hero(string sprite,string name) : base(sprite)
        {
            Equipements = new Equipements();
            Name = name;
            Stats.Generate(Utils.DiceType.D10, 5, 3);
        }

        public void Loot(Character c)
        {

        }

        public override int GetStatValue(StatType stat)
        {
            return Stats[stat] + Equipements.GetStatValue(stat);
        }
    }
}
