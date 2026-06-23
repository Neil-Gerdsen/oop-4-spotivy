// 1. Songs aanmaken
using oop4;
using oop4.classes;




Song song1 = new Song("Blinding Lights", new List<Artist> { new Artist("The Weeknd") }, 5, Genres.Pop); 
Song song2 = new Song("Starboy", new List<Artist> { new Artist("The ferdi") }, 5, Genres.Pop);


// 2. SongCollection aanmaken
SongCollection collectie = new SongCollection("Mijn lijst");

// 3. Songs toevoegen
collectie.AddSong(song1);
collectie.AddSong(song2);

Client client = new Client(new List<Song> { song1, song2 }, collectie);
Person person = new Person("John Doe");
client.HuidigeCollectie = collectie;


bool running = true;

while (running)
{
    Console.WriteLine("\n=== Spotify CLI ===");
    Console.WriteLine("1. Toon alle songs");
    Console.WriteLine("2. Voeg song toe aan favorieten");
    Console.WriteLine("3. Toon favorieten");
    Console.WriteLine("4. Verwijder song uit favorieten");
    Console.WriteLine("5. Play een song");
    Console.WriteLine("6. lijst aanmaken");
    Console.WriteLine("7. lijst tonen");
    Console.WriteLine("8. Kopieer lijst naar andere lijst");


    Console.Write("Kies: ");

    string keuze = Console.ReadLine();

    switch (keuze)
    {
        case "1":
            {
                List<IPlayable> songs = collectie.ShowPlayables();

                for (int i = 0; i < songs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {songs[i]}");
                }
                break;
            }


        case "2":
            {
                List<IPlayable> alleSongs = collectie.ShowPlayables();

                for (int i = 0; i < alleSongs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {alleSongs[i]}");
                }

                Console.Write("\nWelke song wil je toevoegen? ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int addIndex))
                {
                    Console.WriteLine("Voer een nummer in.");
                    break;
                }

                addIndex--;

                if (addIndex < 0 || addIndex >= alleSongs.Count)
                {
                    Console.Write("Niet beschickbaar");
                    break;
                }
                else
                {
                    client.AddToFavorieten(alleSongs[addIndex]);
                    break;
                }
            }


        case "3":
            {
                List<IPlayable> favorieten = client.Favorieten.ShowPlayables();
                if (favorieten.Count > 0)
                {
                    client.ShowFavorieten();
                    break;
                }
                else
                {
                    Console.Write("Je hebt geen favorieten. ");
                    break;
                }

            }


        case "4":
            {
                List<IPlayable> favorieten = client.Favorieten.ShowPlayables();

                for (int i = 0; i < favorieten.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {favorieten[i]}");
                }

                if (favorieten.Count > 0)
                {
                    Console.Write("\nWelke favoriet wil je verwijderen? ");

                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int removeIndex))
                    {
                        Console.WriteLine("Voer een nummer in.");
                        break;
                    }

                    removeIndex--;

                    if (removeIndex < 0 || removeIndex >= favorieten.Count)
                    {
                        Console.Write("Niet beschickbaar");
                        break;
                    }
                    else
                    {
                        client.RemoveFromFavorieten(favorieten[removeIndex]);
                        break;
                    }
                }
                else
                {
                    Console.Write("Je hebt geen favorieten. ");
                    break;
                }
            }

        case "5":
            {
                List<IPlayable> songs = collectie.ShowPlayables();

                Console.WriteLine("\nWelke song wil je afspelen?");

                for (int i = 0; i < songs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {songs[i]}");
                }

                Console.Write("Kies: ");

                if (!int.TryParse(Console.ReadLine(), out int playIndex))
                {
                    Console.WriteLine("Voer een nummer in.");
                    break;
                }

                playIndex--;

                if (playIndex >= 0 && playIndex < songs.Count)
                {
                    client.CurrentlyPlaying = songs[playIndex];
                    client.Play();
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze.");
                }

                break;
            }
        case "6":
            {
                List<Playlist> playlists = client.Playlists;
                Console.Write("Naam van de nieuwe lijst: ");

                string lijstNaam = Console.ReadLine();
                if (playlists.Any(p => p.Title == lijstNaam))
                {
                    Console.WriteLine($"Er bestaat al een lijst met de naam '{lijstNaam}'!");

                }
                else
                {
                    client.CreatePlaylist(lijstNaam);
                    Console.WriteLine($"Nieuwe lijst '{lijstNaam}' is aangemaakt!");
                }
                break;
            }

        case "7":
            {
                List<Playlist> playlists = client.Playlists; // ← client niet person

                if (playlists.Count == 0)
                {
                    Console.WriteLine("Geen playlists gevonden.");
                    break;
                }

                for (int i = 0; i < playlists.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {playlists[i]}");
                }
                break;
            }

        case "8":
            {
                List<Playlist> playlists = client.Playlists;

                if (playlists.Count < 2)
                {
                    Console.WriteLine("Je hebt minimaal 2 playlists nodig om te kopiëren.");
                    break;
                }

                Console.WriteLine("\nWelke lijst wil je kopiëren?");

                for (int i = 0; i < playlists.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {playlists[i]}");
                }

                Console.Write("Bronlijst: ");

                if (!int.TryParse(Console.ReadLine(), out int bronIndex))
                {
                    Console.WriteLine("Voer een nummer in.");
                    break;
                }

                bronIndex--;

                if (bronIndex < 0 || bronIndex >= playlists.Count)
                {
                    Console.WriteLine("Ongeldige keuze.");
                    break;
                }

                Console.WriteLine("\nNaar welke lijst wil je kopiëren?");

                for (int i = 0; i < playlists.Count; i++)
                {
                    if (i != bronIndex)
                    {
                        Console.WriteLine($"{i + 1}. {playlists[i]}");
                    }
                }

                Console.Write("Ontvangende lijst: ");

                if (!int.TryParse(Console.ReadLine(), out int doelIndex))
                {
                    Console.WriteLine("Voer een nummer in.");
                    break;
                }

                doelIndex--;

                if (doelIndex < 0 || doelIndex >= playlists.Count)
                {
                    Console.WriteLine("Ongeldige keuze.");
                    break;
                }

                if (doelIndex == bronIndex)
                {
                    Console.WriteLine("Je kunt een lijst niet naar zichzelf kopiëren.");
                    break;
                }

                Playlist bronLijst = playlists[bronIndex];
                Playlist doelLijst = playlists[doelIndex];

                List<IPlayable> bronSongs = bronLijst.ShowPlayables();
                List<IPlayable> doelSongs = doelLijst.ShowPlayables();

                int toegevoegd = 0;
                int overgeslagen = 0;

                foreach (IPlayable song in bronSongs)
                {
                    if (!doelSongs.Contains(song))
                    {
                        doelLijst.AddSong(song);
                        toegevoegd++;
                    }
                    else
                    {
                        overgeslagen++;
                    }
                }

                Console.WriteLine($"{toegevoegd} liedje(s) toegevoegd aan '{doelLijst}'.");
                Console.WriteLine($"{overgeslagen} dubbele liedje(s) overgeslagen.");

                break;
            }

        default:
            Console.WriteLine("Ongeldige keuze.");
            break;
    }
}
