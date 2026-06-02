using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace oop4.classes
{
    //internal class Song
    //{
        
        public enum Genres
        {
            Pop,
            Rock,
            Jazz,
            Classical,
            HipHop,
            Electronic
        }

        public class Song : IPlayable
    {
            public string Title { get; set; }
            //public List<Artist> Artists { get; set; }
            public Genres SongGenre { get; set; }
            private int Duur { get; set; }

            //public Song(string title, List<Artist> artists, int duur, Genres genre)
            //{
            //    Title = title;
            //    Artists = artists;
            //    Duur = duur;
            //    SongGenre = genre;
            //}
            public Song(string title, int duur, Genres genre)
            {
                Title = title;
                Duur = duur;
                SongGenre = genre;
            }

        public void Play() { Console.WriteLine($"{Title} speelt af"); }
        public void Pause() { Console.WriteLine($"{Title} gepauzeerd"); }
        public void Next() { Console.WriteLine("Volgende nummer"); }
        public void Stop() { Console.WriteLine($"{Title} gestopt"); }
        public int Length => Duur;

        //public override string ToString()
        //{
        //    return $"{Title} - {string.Join(", ", Artists)}";
        //}
        public override string ToString()
            {
                return $"{Title} - {string.Join(", ", Title)}";
            }
    }
    }
//}
