using IceAndFire.Models;
using IceAndFire.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IceAndFire.ViewModels
{
    public class CharactersViewModel : BaseViewModel
    {
        private Character _selectedCharacter;
        public ObservableCollection<Character> SearchResults { get; }
        public Command LoadCharactersCommand { get; }
        public Command<Character> CharacterTapped { get; }
        public Command<string> PerformSearch { get; }

        public CharactersViewModel()
        {
            Title = "Characters";
            SearchResults = new ObservableCollection<Character>();
            PerformSearch = new Command<string>(async (string query) => await ExecuteSearch(query));
            CharacterTapped = new Command<Character>(OnCharacterSelected);
        }
        async Task ExecuteSearch(string param)
        {
            Query = param;

            try
            {
                SearchResults.Clear();
                var characters = await Service.GetCharacterByNameQueryString(Query);
                foreach (var character in characters)
                {
                    SearchResults.Add(character);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public void OnAppearing()
        {
            SelectedCharacter = null;
        }

        public Character SelectedCharacter
        {
            get => _selectedCharacter;
            set
            {
                SetProperty(ref _selectedCharacter, value);
                OnCharacterSelected(value);
            }
        }

        async void OnCharacterSelected(Character character)
        {
            
            if (character == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(CharacterDetailPage)}?{nameof(CharacterDetailViewModel.CharacterId)}={character.url}");
            
        }
    }
}