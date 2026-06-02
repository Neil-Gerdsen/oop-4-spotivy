using System;
using System.Collections.Generic;
using System.Text;

namespace oop4.classes
{
   
    public class Client
    {
            public IPlayable CurrentlyPlaying { get; set; }  
            public int CurrentTime { get; set; }             
            public bool Playing { get; set; }               
            public bool Shuffle { get; set; }
            public bool Repeat { get; set; }
            public SongCollection HuidigeCollectie { get; set; }
        //private SuperUser ActiveUser { get; set; }
        //private List<Album> AllAlbums { get; set; }
        //private List<Song> AllSongs { get; set; }
        //private List<Person> AllUsers { get; set; }

        //public Client(List<Person> users, List<Album> albums, List<Song> songs)
        //{
        //    AllUsers = users;
        //    AllAlbums = albums;
        //    AllSongs = songs;
        //    Playing = false;
        //    CurrentTime = 0;
        //}
        public Client(List<Song> songs, SongCollection collectie)
        {
            HuidigeCollectie = collectie;
            Playing = false;
            CurrentTime = 0;
        }

        public void Play()
        {
            if (CurrentlyPlaying == null && HuidigeCollectie != null)
            {
                CurrentlyPlaying = HuidigeCollectie.Huidig();
            }

            if (CurrentlyPlaying != null)
            {
                CurrentlyPlaying.Play();
                Playing = true;

                Console.WriteLine($"Nu speelt: {CurrentlyPlaying}");
            }
            else
            {
                Console.WriteLine("Geen nummer beschikbaar.");
            }
        }

        public void Pause()
        {
            if (CurrentlyPlaying != null)
            {
                CurrentlyPlaying.Pause();
                Playing = false;
            }
        }

        public void Stop()
        {
            CurrentlyPlaying.Stop();
            Playing = false;
            CurrentTime = 0;
        }
        public void NextSong()
        {
            if (CurrentlyPlaying != null)
            {
                // haal de lijst op van wat er speelt
                SongCollection collectie = (SongCollection)CurrentlyPlaying;
                collectie.Next();
                CurrentlyPlaying = collectie.Huidig();
                CurrentlyPlaying.Play();
            }
        }
    }
}
