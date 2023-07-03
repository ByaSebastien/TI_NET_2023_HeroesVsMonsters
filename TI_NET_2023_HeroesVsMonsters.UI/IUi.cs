using System.Data;
using TI_NET_2023_HeroesVsMonsters.Models.Characters;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Monsters;
using TI_NET_2023_HeroesVsMonsters.Models.Maps;

namespace TI_NET_2023_HeroesVsMonsters.UI
{
    public interface IUi
    {
        void DisplayMap();
        void SetMap(Map map);
        Hero SelectHero();
        void StartFight(Monster monster);
        void FightAction(Character character);
    }
}