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
        public SongCollection Favorieten { get; set; }
        public List<Playlist> Playlists { get; set; }
        private SuperUser ActiveUser { get; set; }
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
            Favorieten = new SongCollection("Favorieten");
            Playing = false;
            CurrentTime = 0;
            Playlists = new List<Playlist>();
        }

        public void AddToFavorieten(IPlayable playable)
        {
            Favorieten.AddSong(playable);
            Console.WriteLine($"{playable} is toegevoegd aan favorieten.");
        }

        public void RemoveFromFavorieten(IPlayable playable)
        {
            Favorieten.Remove(playable);
            Console.WriteLine($"{playable} is verwijderd uit favorieten.");
        }

        public void ShowFavorieten()
        {
            Console.WriteLine("Favorieten:");

            foreach (IPlayable playable in Favorieten.ShowPlayables())
            {
                Console.WriteLine(playable);
            }
        }

        public void Play()
        {
            if (CurrentlyPlaying == null)
            {
                Console.WriteLine("Geen nummer geselecteerd.");
                return;
            }

            Playing = true;

            Console.WriteLine($"Nu speelt: {CurrentlyPlaying}");
            Console.WriteLine("( SPATIE ) om te pauzeren.");
            Console.WriteLine("( >      ) om te skippen.");
            Console.WriteLine("( X      ) om te stoppen.");

            while (CurrentTime < CurrentlyPlaying.Length)
            {
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Spacebar)
                    {
                        Playing = !Playing;

                        if (Playing)
                            Console.WriteLine("Verder afspelen");
                        else
                            Console.WriteLine("Gepauzeerd");
                    }

                    if (key.KeyChar == '.' || key.KeyChar == '>')
                    {
                        Console.WriteLine("Skip naar volgend nummer...");
                        NextSong();
                        return;
                    }

                    if (key.KeyChar == 'X' || key.KeyChar == 'x')
                    {
                        Console.WriteLine("Liedje stoppen");
                        Stop();
                        return;
                    }
                }

                if (Playing)
                {
                    Thread.Sleep(1000);
                    CurrentTime++;
                    Console.WriteLine($"\nNu speelt: {CurrentlyPlaying}\n");
                    Console.WriteLine("( SPATIE ) om te pauzeren.");
                    Console.WriteLine("( >      ) om te skippen.");
                    Console.WriteLine("( X      ) om te stoppen.\n");
                    Console.WriteLine($"{CurrentTime}/{CurrentlyPlaying.Length}\n");
                }
                else
                {
                    Thread.Sleep(50);
                }
            }

            Playing = false;
            CurrentTime = 0;

            Console.WriteLine("Nummer afgelopen.");

            NextSong();
        }

        public void Pause()
        {
            Playing = false;
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
                HuidigeCollectie.Next();
                CurrentlyPlaying = HuidigeCollectie.Huidig();
                CurrentTime = 0;

                Play();
            }
        }

        public Playlist CreatePlaylist(string title)
        {
            Playlist playlist = new Playlist(null, title);
            Playlists.Add(playlist);
            return playlist;
        }

        public void CopySongsToPlaylist(SongCollection bron, Playlist doel)
        {
            foreach (IPlayable song in bron.ShowPlayables())
            {
                if (!doel.ShowPlayables().Contains(song))
                {
                    doel.AddSong(song);
                }
            }

            Console.WriteLine("Liedjes gekopieerd.");
        }
    }
}