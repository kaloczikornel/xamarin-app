using IceAndFire.Models;
using IceAndFire.Services;
using IceAndFire.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IceAndFire.ViewModels
{
    public class BooksViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private Book _selectedBook;

        public ObservableCollection<Book> Books { get; }
        public ObservableCollection<Book> SearchResults { get; }
        public Command LoadBooksCommand { get; }
        public Command AddBookCommand { get; }
        public Command<Book> BookTapped { get; }
        public Command<string> PerformSearch { get; }

        public BooksViewModel()
        {
            Title = "Books";
            Books = new ObservableCollection<Book>();
            SearchResults = new ObservableCollection<Book>();
            //LoadBooksCommand = new Command(async () => await ExecuteLoadBooksCommand());
            PerformSearch = new Command<string>(async (string query) => await ExecuteSearch(query));

            BookTapped = new Command<Book>(OnBookSelected);


        }
        async Task ExecuteSearch(string query)
        {
            IsBusy = true;

            try
            {
                Debug.WriteLine(query);
                SearchResults.Clear();
                var books = await Service.GetBookByNameQueryString(query);
                foreach (var book in books)
                {
                    SearchResults.Add(book);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadBooksCommand()
        {
            IsBusy = true;

            try
            {
                Books.Clear();
                var books = await Service.GetBooksAsync();
                foreach (var book in books)
                {
                    Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedBook = null;
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                SetProperty(ref _selectedBook, value);
                OnBookSelected(value);
            }
        }


        async void OnBookSelected(Book book)
        {
            
            if (book == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?{nameof(BookDetailViewModel.BookId)}={book.url}");
            
        }
    }
}