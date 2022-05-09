using IceAndFire.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace IceAndFire.ViewModels
{
    [QueryProperty(nameof(BookId), nameof(BookId))]
    public class BookDetailViewModel : BaseViewModel
    {
        //private List<Character> LoadedCharacters;
        private string bookId;
        private string name;
        private string isbn;
        private string authors;
        private int numberOfPages;
        private string publisher;
        private string country;
        private string mediaType;
        private DateTime released;
        private string characters;
        private string povCharacters;

        public string Id { get; set; }

        public string BookId
        {
            get
            {
                return bookId;
            }
            set
            {
                bookId = value;
                LoadBookId(value);
            }
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Isbn
        {
            get => isbn;
            set => SetProperty(ref isbn, value);
        }
        public int NumberOfPages
        {
            get => numberOfPages;
            set => SetProperty(ref numberOfPages, value);
        }
        public string Authors
        {
            get => authors;
            set => SetProperty(ref authors, value);
        }
        public string Publisher
        {
            get => publisher;
            set => SetProperty(ref publisher, value);
        }
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }
        public string MediaType
        {
            get => mediaType;
            set => SetProperty(ref mediaType, value);
        }
        public DateTime Released
        {
            get => released;
            set => SetProperty(ref released, value);
        }
        public string Characters
        {
            get => characters;
            set => SetProperty(ref characters, value);
        }
        public string PovCharacters
        {
            get => povCharacters;
            set => SetProperty(ref povCharacters, value);
        }

        public async void LoadBookId(string bookId)
        {
            try
            {
                Book book = await Service.GetBookAsync(bookId);
                Name = book.name;
                Isbn = book.isbn;
                var AuthorsArray = book.authors;
                Authors = Service.StringArrayToString(AuthorsArray);
                NumberOfPages = book.numberOfPages;
                Publisher = book.publisher;
                Country = book.country;
                MediaType = book.mediaType;
                Released = book.released;
                var CharactersArray = book.characters;
                Characters = Service.StringArrayToString(CharactersArray);
                var PovCharactersArray = book.povCharacters;
                PovCharacters = Service.StringArrayToString(PovCharactersArray);

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Book");
            }
        }
    }
}
