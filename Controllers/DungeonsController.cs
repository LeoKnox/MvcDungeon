﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcDungeon.Data;
using MvcDungeon.Models;

namespace MvcDungeon.Controllers
{
    public class DungeonsController : Controller
    {
        private readonly MvcDungeonContext _context;

        public DungeonsController(MvcDungeonContext context)
        {
            _context = context;
        }

        // GET: Dungeons
        public async Task<IActionResult> Index()
        {
            return View(await _context.dungeon.ToListAsync());
        }

        // GET: Dungeons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dungeon = await _context.dungeon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dungeon == null)
            {
                return NotFound();
            }

            return View(dungeon);
        }

        // GET: Dungeons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dungeons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomName,Type,length,width")] Dungeon dungeon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dungeon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dungeon);
        }

        // GET: Dungeons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dungeon = await _context.dungeon.FindAsync(id);
            if (dungeon == null)
            {
                return NotFound();
            }
            return View(dungeon);
        }

        // POST: Dungeons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomName,Type,length,width")] Dungeon dungeon)
        {
            if (id != dungeon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dungeon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DungeonExists(dungeon.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dungeon);
        }

        // GET: Dungeons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dungeon = await _context.dungeon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dungeon == null)
            {
                return NotFound();
            }

            return View(dungeon);
        }

        // POST: Dungeons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dungeon = await _context.dungeon.FindAsync(id);
            _context.dungeon.Remove(dungeon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DungeonExists(int id)
        {
            return _context.dungeon.Any(e => e.Id == id);
        }
    }
}
