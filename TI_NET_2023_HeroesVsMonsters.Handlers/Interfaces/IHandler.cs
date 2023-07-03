using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Monsters;
using TI_NET_2023_HeroesVsMonsters.UI;

namespace TI_NET_2023_HeroesVsMonsters.Handlers.Interfaces
{
    public interface IHandler
    {
        void ReadAction();
        void ReadFightAction(IUi ui, Hero hero, Monster monster);
    }
}
