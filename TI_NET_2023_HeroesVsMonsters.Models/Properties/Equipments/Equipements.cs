using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics;

namespace TI_NET_2023_HeroesVsMonsters.Models.Properties.Equipments
{
    public class Equipements
    {
        private Dictionary<EquipementType, Equipement> _equipements;

        public Equipements()
        {
            _equipements = new Dictionary<EquipementType, Equipement>();
        }
        public Equipement? this[EquipementType type]
        {
            get
            {
                return !_equipements.ContainsKey(type) ? null : _equipements[type];
            }
            set
            {
                if (!_equipements.ContainsKey(type))
                {
                    _equipements.Add(type, value);
                }
                else
                {
                    _equipements[type] = value;
                }
            }
        }

        public int GetStatValue(StatType stat)
        {
            return _equipements.Sum(e => e.Value is null ? 0 : e.Value.Stats[stat]);
        }
    }
}
