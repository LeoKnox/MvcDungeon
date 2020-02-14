using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDungeon.Models
{
    public class Door
    {
        public string Wall { get; set; }
        public int Location { get; set; }
        
        public int RoomId {get; set; }
        public Dungeon Dungeon {get; set; }
    }
}
