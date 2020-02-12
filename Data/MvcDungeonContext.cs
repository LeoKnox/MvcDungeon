using Microsoft.EntityFrameworkCore;
using MvcDungeon.Models;

namespace MvcDungeon.Data
{
    public class MvcDungeonContext : DbContext
    {
        public MvcDungeonContext(DbContextOptions<MvcDungeonContext> options) : base(options)
        {
        }

        public DbSet<Dungeon> Dungeon { get; set; }
    }
}
