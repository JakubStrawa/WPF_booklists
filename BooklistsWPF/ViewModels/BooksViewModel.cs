using BooksWPF.MVVM;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace BooksWPF.ViewModels
{
    public class BooksViewModel : IViewModel, INotifyPropertyChanged
    {
        private BooksModel BooksModel { get; }
        private readonly CollectionViewSource collectionViewSource;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICollectionView Books { get; }

        private Book selectedBook;
        
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                EditCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBook)));
            }
        }

        private string filterText = "";
        public string FilterText
        {
            get
            {
                return filterText;
            }
            set 
            {
                filterText = value;
                UpdateFilter();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterText)));
            }
        }
        private void UpdateFilter()
        {
            collectionViewSource.View.Refresh();
        }
        bool FilterBook(Book book)
        {
            return book.Title.Contains(FilterText) || book.Author.Contains(FilterText);
        }
          
        public Action Close { get; set; }
        private RelayCommand<object> addCommand;
        public RelayCommand<object> AddCommand => (addCommand = addCommand?? new RelayCommand<object>(o=>AddBook()));
        private RelayCommand<object> editCommand;
        public RelayCommand<object> EditCommand => (editCommand = editCommand ?? new RelayCommand<object>(o => EditBook(SelectedBook), o => SelectedBook != null));
        private RelayCommand<object> deleteCommand;
        public RelayCommand<object> DeleteCommand => (deleteCommand = deleteCommand ?? new RelayCommand<object>(o => DeleteBook(SelectedBook), o => SelectedBook != null));

        private RelayCommand<object> newWindowCommand;
        public RelayCommand<object> NewWindowCommand => (newWindowCommand = newWindowCommand ?? new RelayCommand<object>(o => NewWindow()));


        public BooksViewModel(BooksModel booksModel)
        {
            BooksModel = booksModel;
            collectionViewSource = new CollectionViewSource
            {
                Source = BooksModel.Books
            };
            collectionViewSource.View.Filter = (o) => FilterBook((Book)o);
            Books = collectionViewSource.View;
        }

        public void NewWindow()
        {
            BooksViewModel booksViewModel = new BooksViewModel(BooksModel);
            ((App)Application.Current).WindowService.Show(booksViewModel);
        }

        public void AddBook()
        {
            BookViewModel booksViewModel = new BookViewModel(BooksModel, null);
            ((App)Application.Current).WindowService.ShowDialog(booksViewModel);
        }

        public void EditBook(Book book)
        {
            if (book != null)
            {
                BookViewModel bookViewModel = new BookViewModel(BooksModel, book);
                ((App)Application.Current).WindowService.ShowDialog(bookViewModel);
            }
        }
        public void DeleteBook(Book book)
        {
            if( book != null )
                BooksModel.Books.Remove(book);
        }
    }
}
