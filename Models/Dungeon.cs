using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDungeon.Models
{
    public class Dungeon
    {
        public int Id { get; set; }
        [Display(Name = "Room Name")]
        public string RoomName { get; set; }
        public string Type { get; set; }
        public int length { get; set; }
        public int width { get; set; }
    }
}
