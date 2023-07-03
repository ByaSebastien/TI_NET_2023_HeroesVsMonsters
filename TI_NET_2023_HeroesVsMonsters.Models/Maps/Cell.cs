using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_NET_2023_HeroesVsMonsters.Models.Maps
{
    public class Cell
    {
        public Cell(Position position)
        {
            Position = position;
            CurrentContent = ContentType.Empty;
            OldContent = ContentType.Empty;
        }

        public Cell(int x,int y) : this(new Position(x,y)) { }

        public Position Position { get; set; }
        public ContentType CurrentContent { get; set; }
        public ContentType OldContent { get; set; }

        public void ChangeContent(ContentType content)
        {
            OldContent = CurrentContent;
            CurrentContent = content;
        }

        public void RevertContent()
        {
            OldContent = CurrentContent;
            CurrentContent = ContentType.Empty;
        }
    }
}
