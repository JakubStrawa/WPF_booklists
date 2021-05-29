using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksWPF
{
    public class BooksModel
    {
        public ObservableCollection<Book> Books { get; private set; } = new ObservableCollection<Book>();
        public BooksModel()
        {
            Books.Add(new Book("Nowe Milenium", "Jan K. Nowak", Genres.DetectiveStory, new DateTime(2001,03,21), 10));
            Books.Add(new Book("Star Wars", "George Lucas", Genres.Fantasy, new DateTime(1972, 05, 18), 11));
            Books.Add(new Book("Zbiór poetycki", "Vincent van Gogh", Genres.Poetry, new DateTime(1889, 11, 22), 12));
        }
    }
}
