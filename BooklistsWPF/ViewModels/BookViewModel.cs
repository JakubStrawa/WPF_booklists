using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksWPF.MVVM;

namespace BooksWPF.ViewModels
{
    public class BookViewModel : MVVM.IViewModel
    {
        private BooksModel BooksModel { get; }
        private Book Book { get; }
        public Action Close { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public Genres Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public UInt32 ID { get; set; }

        public RelayCommand<BookViewModel> OkCommand { get; } = new RelayCommand<BookViewModel>
            (
                (bookViewModel) => { bookViewModel.Ok(); }
            );
        public RelayCommand<BookViewModel> CancelCommand { get; } = new RelayCommand<BookViewModel>
            (
                (bookViewModel) => { bookViewModel.Cancel(); }
            );

        public BookViewModel(BooksModel booksModel, Book book)
        {
            BooksModel = booksModel;
            Book = book;
            if (Book != null)
            {
                Title = Book.Author;
                Author = Book.Title;
                Genre = Book.Genre;
                ReleaseDate = Book.ReleaseDate;
                ID = Book.ID;
            }
        }

        public void Ok()
        {
            if (Book == null)
            {
                Book book = new Book(Author, Title, Genre, ReleaseDate, ID);
                BooksModel.Books.Add(book);
            }
            else
            {
                Book.Author = Title;
                Book.Title = Author;
                Book.Genre = Genre;
                Book.ReleaseDate = ReleaseDate;
                Book.ID = ID;
            }
            Close?.Invoke();
        }
        public void Cancel() => Close?.Invoke();
    }
}
