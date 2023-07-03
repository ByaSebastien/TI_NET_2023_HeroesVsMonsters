using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Characters;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Monsters;
using TI_NET_2023_HeroesVsMonsters.Models.Maps;

namespace TI_NET_2023_HeroesVsMonsters.UI
{
    public class Ui : IUi
    {
        private Map _map;
        public void DisplayMap()
        {
            for (int i = 0; i < _map.Height; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < _map.Width; j++)
                {
                    switch(_map[j, i].CurrentContent)
                    {
                        case ContentType.Empty:
                            Console.Write("     ");
                            break;
                        case ContentType.Monster:
                            Console.Write("{0,-5}",_map.GetMonster(new Position(j, i)).Sprite);
                            break;
                        case ContentType.Hero:
                            Console.Write("{0,-5}",_map.Hero.Sprite);
                            break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine(_map.Hero);
        }

        public Hero SelectHero()
        {
            Console.WriteLine("1 : Guerrier\n2 : Mage\n3 : Voleur");
            ConsoleKeyInfo cki = Console.ReadKey();
            Console.WriteLine("Nom de votre personnage?");
            string name = Console.ReadLine();

            switch(cki.Key)
            {
                case ConsoleKey.NumPad1:
                    return new Warrior(name);
                case ConsoleKey.NumPad2:
                    return new Mage(name);
                case ConsoleKey.NumPad3:
                    return new Thief(name);
                default:
                    throw new Exception();
            }
        }

        public void SetMap(Map map)
        {
            _map = map;
        }

        public void StartFight(Monster monster)
        {
            Console.WriteLine($"Un monstre sauvage apparait!!!");
            Console.WriteLine(monster);
        }

        public void FightAction(Character character)
        {
            Console.WriteLine($"{character.GetType().Name} attaque!!!");
        }
    }
}
