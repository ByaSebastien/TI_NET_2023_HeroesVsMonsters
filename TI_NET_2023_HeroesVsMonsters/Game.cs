using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Handlers.Handlers;
using TI_NET_2023_HeroesVsMonsters.Handlers.Interfaces;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes;
using TI_NET_2023_HeroesVsMonsters.Models.Maps;
using TI_NET_2023_HeroesVsMonsters.UI;

namespace TI_NET_2023_HeroesVsMonsters
{
    public class Game
    {
        private readonly IHandler _handler;
        private readonly Hero _hero;
        private readonly IUi _ui;

        public Game(IUi ui)
        {
            _ui = ui;
            _hero = ui.SelectHero();
            Map map = new Map(_hero);
            _handler = new InputHandler(map, _hero, ui);
            _ui.SetMap(map);
        }

        public void Start()
        {
            while (_hero.IsAlive)
            {
                PlayTurn();
            }
        }

        private void PlayTurn()
        {
            Console.Clear();
            _ui.DisplayMap();
            _handler.ReadAction();
        }
    }
}
