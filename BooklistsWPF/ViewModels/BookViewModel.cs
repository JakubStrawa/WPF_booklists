using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksWPF.MVVM;
using System.ComponentModel;

namespace BooksWPF.ViewModels
{
    public class BookViewModel : MVVM.IViewModel, INotifyPropertyChanged
    {
        private BooksModel BooksModel { get; }
        private Book Book { get; }
        public Action Close { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        private Genres genre = Genres.Poetry;
        public Genres Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Genre)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PicturePath)));
            }
        }
        public DateTime ReleaseDate { get; set; }
        public UInt32 ID { get; set; }

        private string picturePath = "Resources/poetry.png";

        public event PropertyChangedEventHandler PropertyChanged;

        public string PicturePath
        {
            get
            {
                picturePath = "Resources/" + Genre.ToString().ToLower() + ".png";
                return picturePath;
            }
            set
            {
                picturePath = value;
            }
        }

        public RelayCommand<BookViewModel> OkCommand { get; } = new RelayCommand<BookViewModel>
            (
                (bookViewModel) => { bookViewModel.Ok(); }
            );
        public RelayCommand<BookViewModel> CancelCommand { get; } = new RelayCommand<BookViewModel>
            (
                (bookViewModel) => { bookViewModel.Cancel(); }
            );

        public RelayCommand<BookViewModel> ChangePhotoCommand { get; } = new RelayCommand<BookViewModel>
            (
                (bookViewModel) => { bookViewModel.ChangeImage(); }
            );

        public BookViewModel(BooksModel booksModel, Book book)
        {
            BooksModel = booksModel;
            Book = book;
            if (Book != null)
            {
                Title = Book.Title;
                Author = Book.Author;
                Genre = Book.Genre;
                ReleaseDate = Book.ReleaseDate;
                ID = Book.ID;
            }
            else
            {
                ReleaseDate = DateTime.Now;
                Title = "";
                Author = "";
            }
        }

        public void Ok()
        {
            if (Book == null)
            {
                Book book = new Book(Title, Author, Genre, ReleaseDate, ID);
                BooksModel.Books.Add(book);
            }
            else
            {
                Book.Author = Author;
                Book.Title = Title;
                Book.Genre = Genre;
                Book.ReleaseDate = ReleaseDate;
                Book.ID = ID;
            }
            Close?.Invoke();
        }
        public void Cancel() => Close?.Invoke();

        public void ChangeImage()
        {
            Genre++;
            if ((int) Genre == 3)
                Genre = 0;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Genre)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PicturePath)));
        }
    }
}
