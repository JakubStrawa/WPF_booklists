using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF
{
    public enum Genres
    {
        Poetry, Fantasy, DetectiveStory
    }
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title")); }
        }

        private string author;
        public string Author
        {
            get { return author; }
            set { author = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Author")); }
        }

        private Genres genre;
        public Genres Genre
        {
            get { return genre; }
            set { genre = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Genre")); }
        }

        private DateTime releaseDate;
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReleaseDate")); }
        }

        public Book( string title, string author, Genres genre, DateTime releaseDate)
        {
            Title = title;
            Author = author;
            Genre = genre;
            ReleaseDate = releaseDate;
        }
    }
}