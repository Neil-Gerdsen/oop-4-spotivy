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
            Favorieten = new SongCollection("Favorieten");
            Playing = false;
            CurrentTime = 0;
        }

        public void AddToFavorieten(IPlayable playable)
        {
            Favorieten.Add(playable);
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
            if (CurrentlyPlaying == null) {
                Console.WriteLine("Geen nummer geselecteerd.");
                return;
            }

            Playing = true;

            Console.WriteLine($"Nu speelt: {CurrentlyPlaying}");
            Console.WriteLine("SPATIE om te pauzeren.");

            while (CurrentTime < CurrentlyPlaying.Length) {
                if (Console.KeyAvailable) {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Spacebar) {
                        Pause();
                        Console.WriteLine("Gepauzeerd");

                        while (true) {
                            if (Console.KeyAvailable) {
                                ConsoleKeyInfo resumeKey = Console.ReadKey(true);

                                if (resumeKey.Key == ConsoleKey.Spacebar) {
                                    Playing = true;
                                    Console.WriteLine("Ongepauzeerd");
                                    break;
                                }
                            }
                        }
                    }
                }

                if (Playing) {
                    Thread.Sleep(1000);
                    CurrentTime++;

                    Console.WriteLine(
                        $"{CurrentTime}"
                    );
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

                Play(); // Client.Play opnieuw starten
            }
        }
    }
}
