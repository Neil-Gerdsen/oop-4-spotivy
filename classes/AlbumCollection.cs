using System;
using System.Collections.Generic;
using System.Text;

namespace oop4.classes
{
    public class AlbumCollection
    {
        public string Title { get; set; }
        private List<Album> albums;

        public AlbumCollection(string title)
        {
            Title = title;
            albums = new List<Album>();
        }

        public void AddAlbum(Album album)
        {
            albums.Add(album);
        }

        public List<Album> ShowAlbums()
        {
            return albums;
        }
    }
}
