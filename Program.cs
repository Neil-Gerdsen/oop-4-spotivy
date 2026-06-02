// 1. Songs aanmaken
using oop4;
using oop4.classes;


Song song1 = new Song("Blinding Lights", 5, Genres.Pop);
Song song2 = new Song("Starboy", 230, Genres.Pop);

// 2. SongCollection aanmaken
SongCollection collectie = new SongCollection("Mijn lijst");

// 3. Songs toevoegen
collectie.Add(song1);
collectie.Add(song2);

Client client = new Client(new List<Song> { song1, song2 }, collectie);
client.HuidigeCollectie = collectie;

//test om te zien of favorieten werkt.
client.AddToFavorieten(song1);
client.AddToFavorieten(song2);

client.ShowFavorieten();

client.RemoveFromFavorieten(song1);

client.ShowFavorieten();

client.Play();   
//client.NextSong();
Console.WriteLine("test");

// 4. Songs ophalen en tonen
List<IPlayable> lijst = collectie.ShowPlayables();

foreach (IPlayable p in lijst)
{
    Console.WriteLine(p);  // roept ToString() aan
}