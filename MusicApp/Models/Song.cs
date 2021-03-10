using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Song
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Composer { get; set; }
        public int Year { get; set; }

    }
}
