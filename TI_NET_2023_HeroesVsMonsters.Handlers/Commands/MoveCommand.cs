using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Handlers.Enums;
using TI_NET_2023_HeroesVsMonsters.Handlers.Interfaces;
using TI_NET_2023_HeroesVsMonsters.Models.Characters;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes;
using TI_NET_2023_HeroesVsMonsters.Models.Maps;

namespace TI_NET_2023_HeroesVsMonsters.Handlers.Commands
{
    public class MoveCommand : ICommand
    {
        private Map _map;
        private Hero _hero;
        private Direction _direction;
        private event Predicate<Position> _fightEvent;

        public MoveCommand(Map map, Hero hero, Direction direction, Predicate<Position> fightEvent)
        {
            _map = map;
            _hero = hero;
            _direction = direction;
            _fightEvent = fightEvent;
        }

        public bool CanMove(Position pos)
        {
            (int x, int y) = pos;
            if (_map.IsOut(pos))
                return false;
            return _map[pos].CurrentContent == ContentType.Empty;
        }

        public void Execute(Position pos)
        {
            if (!CanMove(pos))
            {
                if (_map.IsOut(pos))
                {
                    return;
                }
                if (_map[pos].CurrentContent == ContentType.Monster)
                {
                    if (_fightEvent.Invoke(pos))
                    {
                        _map.RemoveMonster(pos);
                    }
                }
            }
            _map[_hero.Position].RevertContent();
            _hero.Position = pos;
            _map[pos].ChangeContent(ContentType.Hero);
        }

        public void Execute()
        {
            (int x, int y) = _hero.Position;

            switch (_direction)
            {
                case Direction.North:
                    Execute(new Position(x, y - 1));
                    break;
                case Direction.South:
                    Execute(new Position(x, y + 1));
                    break;
                case Direction.East:
                    Execute(new Position(x + 1, y));
                    break;
                case Direction.West:
                    Execute(new Position(x - 1, y));
                    break;
            }
        }
    }
}
