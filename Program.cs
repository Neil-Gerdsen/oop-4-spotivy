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
                    Console.WriteLine($"{i}. {songs[i]}");
                }
                break;
            }


        case "2":
            {
                List<IPlayable> alleSongs = collectie.ShowPlayables();

                for (int i = 0; i < alleSongs.Count; i++)
                {
                    Console.WriteLine($"{i}. {alleSongs[i]}");
                }

                Console.Write("Welke song wil je toevoegen? ");
                int addIndex = int.Parse(Console.ReadLine());

                client.AddToFavorieten(alleSongs[addIndex]);
                break;
            }


        case "3":
            {
                client.ShowFavorieten();
                break;
            }


        case "4":
            {
                List<IPlayable> favorieten = client.Favorieten.ShowPlayables();

                for (int i = 0; i < favorieten.Count; i++)
                {
                    Console.WriteLine($"{i}. {favorieten[i]}");
                }

                if (favorieten.Count > 0)
                {
                    Console.Write("Welke favoriet wil je verwijderen? ");
                    int removeIndex = int.Parse(Console.ReadLine());

                    client.RemoveFromFavorieten(favorieten[removeIndex]);
                    break;
                }
                else

                    Console.Write("Je hebt geen favorieten. ");
                break;
            }


        case "5":
            {
                List<IPlayable> songs = collectie.ShowPlayables();

                Console.WriteLine("Welke song wil je afspelen?");

                for (int i = 0; i < songs.Count; i++)
                {
                    Console.WriteLine($"{i}. {songs[i]}");
                }

                Console.Write("Kies: ");
                int playIndex = int.Parse(Console.ReadLine());

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