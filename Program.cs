// 1. Songs aanmaken
using oop4;
using oop4.classes;


Song song1 = new Song("Blinding Lights", 5, Genres.Pop);
Song song2 = new Song("Starboy", 5, Genres.Pop);

// 2. SongCollection aanmaken
SongCollection collectie = new SongCollection("Mijn lijst");

// 3. Songs toevoegen
collectie.Add(song1);
collectie.Add(song2);

Client client = new Client(new List<Song> { song1, song2 }, collectie);
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

        default:
            Console.WriteLine("Ongeldige keuze.");
            break;
    }
}