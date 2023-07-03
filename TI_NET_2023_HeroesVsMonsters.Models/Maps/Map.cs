using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Characters;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Heroes;
using TI_NET_2023_HeroesVsMonsters.Models.Characters.Monsters;

namespace TI_NET_2023_HeroesVsMonsters.Models.Maps
{
    public class Map
    {
        public int Width = 20;
        public int Height = 8;
        private int NbMonsters = 50;

        public Hero Hero { get; set; }
        public Dictionary<Position, Monster> Monsters { get; }
        public Cell[,] Cells { get; }
        public Cell this[Position pos] => Cells[pos.X,pos.Y];
        public Cell this[int x, int y] => Cells[x,y];

        public Map(Hero hero)
        {
            Monsters = new Dictionary<Position, Monster>();
            Cells = new Cell[Width,Height];

            for (int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    Cells[i,j] = new Cell(i,j);
                }
            }
            Hero = hero;
            Hero.Position = new Position(9,7);
            this[Hero.Position].ChangeContent(ContentType.Hero);

            Position pos;
            Random r = new Random();

            for (int i = 0;i < NbMonsters;i++)
            {
                Monster monster = MonsterFactory.GenerateMonster();

                do
                {
                    pos = new Position(r.Next(Width), r.Next(Height));
                } while (this[pos].CurrentContent != ContentType.Empty);

                monster.Position = pos;
                monster.DieEvent += Hero.Loot;
                Monsters.Add(pos, monster);
                this[pos].ChangeContent(ContentType.Monster);
            }
        }
        public Monster GetMonster(Position pos)
        {
            return Monsters[pos];
        }

        public bool IsOut(Position pos)
        {
            (int x, int y) = pos;
            if (x < 0 || x >= Width) return true;
            if (y < 0 || y >= Height) return true;
            return false;
        }

        public void RemoveMonster(Position pos)
        {
            this[pos].RevertContent();
            Monsters.Remove(pos);
        }
    }
}
