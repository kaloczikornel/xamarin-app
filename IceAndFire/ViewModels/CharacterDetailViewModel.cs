using IceAndFire.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace IceAndFire.ViewModels
{
    [QueryProperty(nameof(CharacterId), nameof(CharacterId))]
    public class CharacterDetailViewModel : BaseViewModel
    {
        private string characterId;
        private string name;
        private string gender;
        private string culture;
        private string born;
        private string died;
        private string titles;
        private string aliases;
        private string father;
        private string mother;
        private string spouse;
        private string allegiances;
        private string books;
        private string povBooks;
        private string tvSeries;
        private string playedBy;

        public string Id { get; set; }



        public string CharacterId
        {
            get
            {
                return characterId;
            }
            set
            {
                characterId = value;
                LoadCharacterId(value);
            }
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }

        public string Culture
        {
            get => culture;
            set => SetProperty(ref culture, value);
        }
        public string Born
        {
            get => born;
            set => SetProperty(ref born, value);
        }
        public string Died
        {
            get => died;
            set => SetProperty(ref died, value);
        }
        public string Titles
        {
            get => titles;
            set => SetProperty(ref titles, value);
        }
        public string Aliases
        {
            get => aliases;
            set => SetProperty(ref aliases, value);
        }
        public string Father
        {
            get => father;
            set => SetProperty(ref father, value);
        }
        public string Mother
        {
            get => mother;
            set => SetProperty(ref mother, value);
        }
        public string Spouse
        {
            get => spouse;
            set => SetProperty(ref spouse, value);
        }
        public string Allegiances
        {
            get => allegiances;
            set => SetProperty(ref allegiances, value);
        }
        public string Books
        {
            get => books;
            set => SetProperty(ref books, value);
        }
        public string PovBooks
        {
            get => povBooks;
            set => SetProperty(ref povBooks, value);
        }
        public string TvSeries
        {
            get => tvSeries;
            set => SetProperty(ref tvSeries, value);
        }
        public string PlayedBy
        {
            get => playedBy;
            set => SetProperty(ref playedBy, value);
        }

        public async void LoadCharacterId(string bookId)
        {
            try
            {
                Character character = await Service.GetCharacterAsync(characterId);
                Name = character.name;
                Gender = character.gender;
                Culture = character.culture;
                Born = character.born;
                Died = character.died;
                var TitlesArray = character.titles;
                Titles = Service.StringArrayToString(TitlesArray);
                var AliasesArray = character.aliases;
                Aliases = Service.StringArrayToString(AliasesArray);
                Father = character.father;
                Mother = character.mother;
                Spouse = character.spouse;
                var AllegiancesArray = character.allegiances;
                Allegiances = Service.StringArrayToString(AllegiancesArray);
                var BooksArray = character.books;
                Books = Service.StringArrayToString(BooksArray);
                var PovBooksArray = character.povBooks;
                PovBooks = Service.StringArrayToString(PovBooksArray);
                var TvSeriesArray = character.tvSeries;
                TvSeries = Service.StringArrayToString(TvSeriesArray);
                var PlayedByArray = character.playedBy;
                PlayedBy = Service.StringArrayToString(PlayedByArray);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Character");
            }
        }
    }
}
