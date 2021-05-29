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

        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Index { get; set; }
        public string Group { get; set; }

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
                Name = Book.Name;
                Surname = Book.Surname;
                Index = Book.Index;
                Group = Book.Group;
            }
        }

        public void Ok()
        {
            if (Book == null)
            {
                Book book = new Book(Surname, Name, Index, Group);
                BooksModel.Books.Add(book);
            }
            else
            {
                Book.Name = Name;
                Book.Surname = Surname;
                Book.Index = Index;
                Book.Group = Group;
            }
            Close?.Invoke();
        }
        public void Cancel() => Close?.Invoke();
    }
}
