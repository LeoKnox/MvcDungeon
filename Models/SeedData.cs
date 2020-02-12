using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcDungeon.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDungeon.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcDungeonContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcDungeonContext>>()))
            {
                if (context.Dungeon.Any())
                {
                    return;
                }

                context.Dungeon.AddRange(
                    new Dungeon
                    {
                        RoomName = "Entry",
                        Type = "Stone",
                        length = 3,
                        width = 5
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
