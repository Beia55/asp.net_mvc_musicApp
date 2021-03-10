using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.Models;

namespace MusicApp.Data
{
    public class MusicAppContext : DbContext
    {
        public MusicAppContext (DbContextOptions<MusicAppContext> options)
            : base(options)
        {
        }

        public DbSet<MusicApp.Models.Song> Song { get; set; }
    }
}
