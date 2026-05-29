using System;
using System.Collections.Generic;
using System.Text;

namespace oop4.classes
{
    public class SongCollection
    {
        public string Title { get; set; }

        private List<IPlayable> playables { get; set; }

        public SongCollection(string title)
        {
            Title = title;
            playables = new List<IPlayable>();

        }

        public override string ToString()
        {
            return $"{Title} - {string.Join(", ", ShowPlayables)}";
        }

        public List<IPlayable> ShowPlayables()
        {

            return playables;
        }

        public void Add(IPlayable playable)
        {
            playables.Add(playable); // song toevoegen
        }

    }
}
