using System;
using System.Collections.Generic;
using System.Text;

namespace oop4.classes
{
    public class Playlist : SongCollection
    {
        public Person Owner { get; set; }

        public Playlist(Person owner, string title) : base(title)
        {
            Owner = owner;
        }
        public override string ToString()
        {
            return Title; // ← toevoegen
        }
        //public Playlist(string title) : base(title)
        //{
        //    Owner = null; // geen eigenaar
        //}

        public void Add(IPlayable playable)
        {
            playables.Add(playable); 
        }
        
    }
}
