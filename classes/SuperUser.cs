using System;
using System.Collections.Generic;
using System.Text;

namespace oop4.classes
{
    public class SuperUser : Person
    {
        public SuperUser(string naam) : base(naam) { }

        public Playlist CreatePlaylist(string title)
        {
            Playlist playlist = new Playlist(this, title);
            // toevoegen aan lijst van person
            return playlist;
        }

    }
}
