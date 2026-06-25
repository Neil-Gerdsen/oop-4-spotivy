using System;
using System.Collections.Generic;
using System.Text;

namespace oop4.classes
{
    public class Album : SongCollection
    {
        public List<Artist> Artists { get; set; }

        public Album(List<Artist> artists, string title) : base(title)
        {
            Artists = artists;
        }

        public override string ToString()
        {
            return $"{Title} - {string.Join(", ", Artists)}";
        }
    }
}
