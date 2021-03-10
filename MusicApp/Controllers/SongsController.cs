using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class SongsController : Controller
    {
        static List<Song> songsList = new List<Song>()
        {
            new Song(){ ID = Guid.NewGuid(), Name = "I'll Live in Glory",Composer = "Whisnants", Year = 2007},
            new Song(){ ID = Guid.NewGuid(), Name = "East to West",Composer = "Casting Crowns", Year = 2010},
            new Song(){ ID = Guid.NewGuid(), Name = "What Faith Can Do",Composer = "Kutless", Year = 2009},
        };

        // GET: Songs
        public IActionResult Index()
        {
            return View(songsList);
        }

        // GET: Songs/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = songsList.FirstOrDefault(m => m.ID == id);
            //var song = songsList.Find(m => m.ID == id);

            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Composer,Year")] Song song)
        {
            if (ModelState.IsValid)
            {
                song.ID = Guid.NewGuid();
                songsList.Add(song);
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = songsList.Find(m => m.ID == id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ID,Name,Composer,Year")] Song song)
        {
            if (id != song.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentSong = songsList.FirstOrDefault(m => m.ID == id);
                currentSong.Name = song.Name;
                currentSong.Composer = song.Composer;
                currentSong.Year = song.Year;
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = songsList.FirstOrDefault(m => m.ID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var song = songsList.Find(m => m.ID == id);
            songsList.Remove(song);
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(Guid id)
        {
            return songsList.Any(e => e.ID == id);
        }
    }
}
