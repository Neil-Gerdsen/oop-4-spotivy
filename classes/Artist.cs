using System;
using System.Collections.Generic;
using System.Text;

namespace oop4.classes
{
    public class Artist
    {
        public string Naam { get; set; }
        //private List<Album> Albums { get; set; }
        private List<Song> Songs { get; set; }
        public Artist(string naam) {

            Naam = naam;
        }
        public override string ToString()
        {
            return Naam;
        }
    }
}