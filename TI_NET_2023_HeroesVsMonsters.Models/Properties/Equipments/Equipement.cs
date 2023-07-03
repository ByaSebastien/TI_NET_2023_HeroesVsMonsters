using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics;

namespace TI_NET_2023_HeroesVsMonsters.Models.Properties.Equipments
{
    public class Equipement
    {
        public Stats Stats { get; set; }
        public EquipementType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Equipement(string name, string description)
        {
            Stats = new Stats();
            Name = name;
            Description = description;
        }
    }
}
