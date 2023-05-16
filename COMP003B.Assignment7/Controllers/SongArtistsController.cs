using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.Assignment7.Data;
using COMP003B.Assignment7.Models;

namespace COMP003B.Assignment7.Controllers
{
    public class SongArtistsController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public SongArtistsController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: SongArtists
        public async Task<IActionResult> Index()
        {
            var webDevAcademyContext = _context.SongArtists.Include(s => s.Artist).Include(s => s.Song);
            return View(await webDevAcademyContext.ToListAsync());
        }

        // GET: SongArtists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SongArtists == null)
            {
                return NotFound();
            }

            var songArtist = await _context.SongArtists
                .Include(s => s.Artist)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songArtist == null)
            {
                return NotFound();
            }

            return View(songArtist);
        }

        // GET: SongArtists/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistAlias");
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "SongAlbum");
            return View();
        }

        // POST: SongArtists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SongId,ArtistId")] SongArtist songArtist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songArtist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistAlias", songArtist.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "SongAlbum", songArtist.SongId);
            return View(songArtist);
        }

        // GET: SongArtists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SongArtists == null)
            {
                return NotFound();
            }

            var songArtist = await _context.SongArtists.FindAsync(id);
            if (songArtist == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistAlias", songArtist.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "SongAlbum", songArtist.SongId);
            return View(songArtist);
        }

        // POST: SongArtists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SongId,ArtistId")] SongArtist songArtist)
        {
            if (id != songArtist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songArtist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongArtistExists(songArtist.Id))
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
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "ArtistAlias", songArtist.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Songs, "SongId", "SongAlbum", songArtist.SongId);
            return View(songArtist);
        }

        // GET: SongArtists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SongArtists == null)
            {
                return NotFound();
            }

            var songArtist = await _context.SongArtists
                .Include(s => s.Artist)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songArtist == null)
            {
                return NotFound();
            }

            return View(songArtist);
        }

        // POST: SongArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SongArtists == null)
            {
                return Problem("Entity set 'WebDevAcademyContext.SongArtists'  is null.");
            }
            var songArtist = await _context.SongArtists.FindAsync(id);
            if (songArtist != null)
            {
                _context.SongArtists.Remove(songArtist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongArtistExists(int id)
        {
          return (_context.SongArtists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
