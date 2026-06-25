// 1. Songs aanmaken
using oop4;
using oop4.classes;

Song song1 = new Song("Blinding Lights", new List<Artist> { new Artist("The Weeknd") }, 100, Genres.Pop); 
Song song2 = new Song("Starboy", new List<Artist> { new Artist("The ferdi") }, 100, Genres.Pop);

// 2. SongCollection aanmaken
SongCollection collectie = new SongCollection("Mijn lijst");

// 3. Songs toevoegen
collectie.AddSong(song1);
collectie.AddSong(song2);

Client client = new Client(new List<Song> { song1, song2 }, collectie);
Person person = new Person("John Doe");
List<Playlist> playlists = client.Playlists;

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
                List<IPlayable> favorieten = client.Favorieten.ShowPlayables();

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
                else if (favorieten.Contains(alleSongs[addIndex]))
                {
                    Console.WriteLine("Deze song staat al in je favorieten.");
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
                int keuzeNummer;

                if (playlists.Count == 0)
                {
                    Console.WriteLine("Geen playlists gevonden.");
                    break;
                }

                // Playlist kiezen
                Console.WriteLine("=== Jouw playlists ===");
                for (int i = 0; i < playlists.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {playlists[i]}");
                }
                Console.WriteLine("0. Terug");
                Console.Write("Kies een playlist: ");

                string keuzeInput = Console.ReadLine();
                if (!int.TryParse(keuzeInput, out keuzeNummer) || keuzeNummer == 0)
                    break;

                if (keuzeNummer < 1 || keuzeNummer > playlists.Count)
                {
                    Console.WriteLine("Ongeldige keuze.");
                    break;
                }

                Playlist gekozenPlaylist = playlists[keuzeNummer - 1];

                // Submenu voor gekozen playlist
                bool inPlaylist = true;
                while (inPlaylist)
                {
                    Console.WriteLine($"\n=== {gekozenPlaylist.Title} ===");

                    var nummers = gekozenPlaylist.ShowPlayables(); // ← pas aan naar jouw property naam
                    if (nummers.Count == 0)
                    {
                        Console.WriteLine("Geen nummers in deze playlist.");
                    }
                    else
                    {
                        for (int i = 0; i < nummers.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {nummers[i]}");
                        }
                    }

                    Console.WriteLine("\n1. Nummer toevoegen");
                    Console.WriteLine("\n2. Lijst afspelen");
                    Console.WriteLine("0. Terug");
                    Console.Write("Keuze: ");

                    string subKeuze = Console.ReadLine();

                    switch (subKeuze)
                    {

                        case "2":
                            List<IPlayable> nummersAfspelen = gekozenPlaylist.ShowPlayables();
                            if (nummersAfspelen.Count == 0)
                            {
                                Console.WriteLine("Geen nummers in deze playlist.");
                                break;
                            }

                            SongCollection tijdelijkeCollectie = new SongCollection(gekozenPlaylist.Title);
                            foreach (IPlayable playable in nummersAfspelen)
                            {
                                tijdelijkeCollectie.AddSong(playable);
                            }

                            client.HuidigeCollectie = tijdelijkeCollectie;
                            client.CurrentlyPlaying = tijdelijkeCollectie.Huidig();
                            client.Play();

                            break;
                        case "1":
                            List<IPlayable> alleSongs = collectie.ShowPlayables(); // ← pas aan naar jouw methode/property
                            if (alleSongs.Count == 0)
                            {
                                Console.WriteLine("Geen nummers beschikbaar.");
                                break;
                            }

                            Console.WriteLine("\n=== Beschikbare nummers ===");
                            for (int i = 0; i < alleSongs.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {alleSongs[i]}");
                            }
                            Console.Write("Kies een nummer om toe te voegen: ");

                            string songInput = Console.ReadLine();
                            if (int.TryParse(songInput, out int songKeuze) &&
                                songKeuze >= 1 && songKeuze <= alleSongs.Count)
                            {
                                gekozenPlaylist.Add(alleSongs[songKeuze - 1]);
                                Console.WriteLine($"'{alleSongs[songKeuze - 1]}' toegevoegd aan '{gekozenPlaylist.Title}'!");
                            }
                            else
                            {
                                Console.WriteLine("Ongeldige keuze.");
                            }
                            break;


                        case "0":
                            inPlaylist = false;
                            break;

                        default:
                            Console.WriteLine("Ongeldige keuze.");
                            break;
                    }
                }

                break;
            }

        case "8":
            {

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

