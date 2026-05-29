// 1. Songs aanmaken
using oop4.classes;


Song song1 = new Song("Blinding Lights", 200, Genres.Pop);
Song song2 = new Song("Starboy", 230, Genres.Pop);

// 2. SongCollection aanmaken
SongCollection collectie = new SongCollection("Mijn lijst");

// 3. Songs toevoegen
collectie.Add(song1);
collectie.Add(song2);



// 4. Songs ophalen en tonen
List<IPlayable> lijst = collectie.ShowPlayables();

foreach (IPlayable p in lijst)
{
    Console.WriteLine(p);  // roept ToString() aan
}