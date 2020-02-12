using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDungeon.Models
{
    public class DungeonTypeViewModel
    {
        public List<Dungeon> Dungeons { get; set; }
        public SelectList Types { get; set; }
        public string DungeonType { get; set; }
        public string SearchString { get; set; }
    }
}
