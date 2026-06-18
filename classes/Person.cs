using System;
using System.Collections.Generic;
using System.Text;

namespace oop4.classes
{
    public class Person
    {
        public string Name { get; set; }

        private List<Playlist> Playlists { get; set; }

        public Person(string name)
        {
            Name = name;
            Playlists = new List<Playlist>();
        }
        public List<Playlist> ShowPlaylists()
        {
            return Playlists;
        }
        public Playlist SelectPlaylist(int index)
        {
            return Playlists[index];
        }
     
}
}
