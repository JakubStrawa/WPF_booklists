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
            Books.Add(new Book("Kowalski", "Henryk", 12, "1T1"));
            Books.Add(new Book("Nowak", "Adam", 12, "2T3"));
            Books.Add(new Book("Abacki", "Jan", 12, "2T2"));
        }
    }
}
