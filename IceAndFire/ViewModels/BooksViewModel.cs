using IceAndFire.Models;
using IceAndFire.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IceAndFire.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {
        private Book _selectedBook;
        public ObservableCollection<Book> SearchResults { get; }
        public Command LoadBooksCommand { get; }
        public Command<Book> BookTapped { get; }
        public Command<string> PerformSearch { get; }

        public BooksViewModel()
        {
            Title = "Books";
            SearchResults = new ObservableCollection<Book>();
            PerformSearch = new Command<string>(async (string query) => await ExecuteSearch(query));
            BookTapped = new Command<Book>(OnBookSelected);
        }
        async Task ExecuteSearch(string param)
        {
            Query = param;

            try
            {
                SearchResults.Clear();
                var books = await Service.GetBookByNameQueryString(Query);
                foreach (var book in books)
                {
                    SearchResults.Add(book);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public void OnAppearing()
        {
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