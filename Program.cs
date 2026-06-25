// 1. Songs aanmaken
using oop4;
using oop4.classes;

Song song1 = new Song("Blinding Lights", new List<Artist> { new Artist("The Weeknd") }, 100, Genres.Pop); 
Song song2 = new Song("Starboy", new List<Artist> { new Artist("The ferdi") }, 100, Genres.Pop);

Song song3 = new Song("Enemies", new List<Artist> { new Artist("Arcane") }, 100, Genres.Electronic);
Song song4 = new Song("Wasteland", new List<Artist> { new Artist("Arcane") }, 100, Genres.Electronic);

Song song5 = new Song("This Love", new List<Artist> { new Artist("Maroon 5") }, 100, Genres.Pop);
Song song6 = new Song("Harder to Breathe", new List<Artist> { new Artist("Maroon 5") }, 100, Genres.Pop);

// 2. SongCollection aanmaken
SongCollection collectie = new SongCollection("Mijn lijst");

// 3. Songs toevoegen
collectie.AddSong(song1);
collectie.AddSong(song2);

// 4. Albums maken
Artist arcane = new Artist("Arcane");
Artist maroon5 = new Artist("Maroon 5");

// 5. Album collectie aanmaken
Album album1 = new Album(new List<Artist> { arcane }, "leage of legends");
Album album2 = new Album(new List<Artist> { maroon5 }, "Songs About Jane");

// 6. Songs toevoegen aan album
album1.AddSong(song3);
album1.AddSong(song4);

album2.AddSong(song5);
album2.AddSong(song6);

AlbumCollection albumCollectie = new AlbumCollection("Alle albums");
albumCollectie.AddAlbum(album1);
albumCollectie.AddAlbum(album2);

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
    Console.WriteLine("8. Kopieer lijst/album naar andere lijst");
    Console.WriteLine("9. Albums tonen en afspelen");


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

                    var nummers = gekozenPlaylist.ShowPlayables();
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
                    Console.WriteLine("\n3. Nummer verwijderen");

                    Console.WriteLine("0. Terug");
                    Console.Write("Keuze: ");

                    string subKeuze = Console.ReadLine();

                    switch (subKeuze)
                    {

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


                        case "3":


                            if (nummers.Count == 0)
                            {
                                Console.WriteLine("De playlist bevat geen nummers.");
                                break;
                            }

                            Console.WriteLine("\n=== Nummers in playlist ===");

                            for (int i = 0; i < nummers.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {nummers[i]}");
                            }

                            Console.Write("\nWelk nummer wil je verwijderen? ");

                            string input = Console.ReadLine();

                            if (!int.TryParse(input, out int removeIndex))
                            {
                                Console.WriteLine("Voer een geldig nummer in.");
                                break;
                            }

                            removeIndex--;

                            if (removeIndex < 0 || removeIndex >= nummers.Count)
                            {
                                Console.WriteLine("Nummer niet beschikbaar.");
                                break;
                            }

                            gekozenPlaylist.Remove(nummers[removeIndex]);

                            Console.WriteLine("Nummer verwijderd uit de playlist.");

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
                List<Album> albums = albumCollectie.ShowAlbums();

                if (playlists.Count == 0)
                {
                    Console.WriteLine("Je hebt minimaal 1 playlist nodig als ontvangende lijst.");
                    break;
                }

                Console.WriteLine("\nWat wil je kopiëren?");
                Console.WriteLine("1. Playlist");
                Console.WriteLine("2. Album");
                Console.Write("Kies bron type: ");

                if (!int.TryParse(Console.ReadLine(), out int bronType))
                {
                    Console.WriteLine("Voer een nummer in.");
                    break;
                }

                SongCollection bronCollectie;

                if (bronType == 1)
                {
                    Console.WriteLine("\nWelke playlist wil je kopiëren?");

                    for (int i = 0; i < playlists.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {playlists[i]}");
                    }

                    Console.Write("Bronplaylist: ");

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

                    bronCollectie = playlists[bronIndex];
                }
                else if (bronType == 2)
                {
                    Console.WriteLine("\nWelk album wil je kopiëren?");

                    for (int i = 0; i < albums.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {albums[i]}");
                    }

                    Console.Write("Bronalbum: ");

                    if (!int.TryParse(Console.ReadLine(), out int albumIndex))
                    {
                        Console.WriteLine("Voer een nummer in.");
                        break;
                    }

                    albumIndex--;

                    if (albumIndex < 0 || albumIndex >= albums.Count)
                    {
                        Console.WriteLine("Ongeldige keuze.");
                        break;
                    }

                    bronCollectie = albums[albumIndex];
                }
                else
                {
                    Console.WriteLine("Ongeldige keuze.");
                    break;
                }

                Console.WriteLine("\nNaar welke playlist wil je kopiëren?");

                for (int i = 0; i < playlists.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {playlists[i]}");
                }

                Console.Write("Ontvangende playlist: ");

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

                Playlist doelLijst = playlists[doelIndex];

                if (bronCollectie == doelLijst)
                {
                    Console.WriteLine("Je kunt een lijst niet naar zichzelf kopiëren.");
                    break;
                }

                List<IPlayable> bronSongs = bronCollectie.ShowPlayables();
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

        case "9":
            {
                List<Album> albums = albumCollectie.ShowAlbums();

                if (albums.Count == 0)
                {
                    Console.WriteLine("Geen albums beschikbaar.");
                    break;
                }

                Console.WriteLine("\n=== Albums ===");

                for (int i = 0; i < albums.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {albums[i]}");
                }

                Console.Write("Welk album wil je afspelen? ");

                if (!int.TryParse(Console.ReadLine(), out int albumIndex))
                {
                    Console.WriteLine("Voer een nummer in.");
                    break;
                }

                albumIndex--;

                if (albumIndex < 0 || albumIndex >= albums.Count)
                {
                    Console.WriteLine("Ongeldige keuze.");
                    break;
                }

                Album gekozenAlbum = albums[albumIndex];

                if (gekozenAlbum.ShowPlayables().Count == 0)
                {
                    Console.WriteLine("Dit album heeft geen nummers.");
                    break;
                }

                client.HuidigeCollectie = gekozenAlbum;
                client.CurrentlyPlaying = gekozenAlbum.Huidig();
                client.Play();

                break;
            }

        default:
            Console.WriteLine("Ongeldige keuze.");
            break;
    }
    


    }

