using System;
using System.Collections.Generic;
using System.Text;

namespace oop4.classes
{
    public class SongCollection
    {
        public string Title { get; set; }


        protected List<IPlayable> playables { get; set; }
        private int huidigIndex = 0;


        public SongCollection(string title)
        {
            Title = title;
            playables = new List<IPlayable>();

        }
        public override string ToString()
        {
            return Title; // ← toevoegen
        }

        public IPlayable Huidig()
        {
            return playables[huidigIndex];
        }

        public void Next()
        {
            if (huidigIndex < playables.Count - 1)
                huidigIndex++;
            else
                huidigIndex = 0;
        }
        

        public List<IPlayable> ShowPlayables()
        {

            return playables;
        }

        public void AddSong(IPlayable playable)
        {
            playables.Add(playable); // song toevoegen
        }

        public void Remove(IPlayable playable)
        {
            playables.Remove(playable); // song verwijderen
        }

    }
}
