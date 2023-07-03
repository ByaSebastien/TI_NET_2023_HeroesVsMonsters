using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Handlers.Commands;
using TI_NET_2023_HeroesVsMonsters.Handlers.Enums;
using TI_NET_2023_HeroesVsMonsters.Handlers.Interfaces;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Monsters;
using TI_NET_2023_HeroesVsMonsters.Models.Maps;
using TI_NET_2023_HeroesVsMonsters.UI;

namespace TI_NET_2023_HeroesVsMonsters.Handlers.Handlers
{
    public class InputHandler : IHandler
    {
        private ICommand _moveNorth;
        private ICommand _moveSouth;
        private ICommand _moveEast;
        private ICommand _moveWest;


        public InputHandler(Map map, Hero hero, IUi ui)
        {
            _moveNorth = new MoveCommand(map, hero, Direction.North, (pos) => HandleFightEvent(ui, hero, map.GetMonster(pos)));
            _moveSouth = new MoveCommand(map, hero, Direction.South, (pos) => HandleFightEvent(ui, hero, map.GetMonster(pos)));
            _moveEast = new MoveCommand(map, hero, Direction.East, (pos) => HandleFightEvent(ui, hero, map.GetMonster(pos)));
            _moveWest = new MoveCommand(map, hero, Direction.West, (pos) => HandleFightEvent(ui, hero, map.GetMonster(pos)));
        }

        public bool HandleFightEvent(IUi ui, Hero hero, Monster monster)
        {
            ui.StartFight(monster);
            while (hero.IsAlive && monster.IsAlive)
            {
                ReadFightAction(ui, hero, monster);
            }
            return hero.IsAlive;
        }

        public void ReadAction()
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);

            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    _moveNorth.Execute();
                    break;
                case ConsoleKey.DownArrow:
                    _moveSouth.Execute();
                    break;
                case ConsoleKey.LeftArrow:
                    _moveWest.Execute();
                    break;
                case ConsoleKey.RightArrow:
                    _moveEast.Execute();
                    break;
            }
        }

        public void ReadFightAction(IUi ui, Hero hero, Monster monster)
        {
            if (monster.Speed > hero.Speed)
            {
                monster.Attack(hero);
                ui.FightAction(monster);
                Console.ReadKey(true);
            }

            if (hero.IsAlive)
            {

                ConsoleKeyInfo cki = Console.ReadKey(true);

                switch (cki.Key)
                {
                    case ConsoleKey.A:
                        hero.Attack(monster);
                        ui.FightAction(hero);
                        break;
                    case ConsoleKey.H:
                        hero.RegenHp(10);
                        break;
                }
                Console.ReadKey(true);
            }

            if (monster.IsAlive && monster.Speed <= hero.Speed)
            {
                monster.Attack(hero);
                ui.FightAction(monster);
                Console.ReadKey(true);
            }
        }
    }
}
