using IceAndFire.Models;
using IceAndFire.Services;
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

        public ObservableCollection<Character> Characters { get; }
        public Command LoadCharactersCommand { get; }
        public Command<Character> CharacterTapped { get; }

        public CharactersViewModel()
        {
            Title = "Characters";
            Characters = new ObservableCollection<Character>();
            LoadCharactersCommand = new Command(async () => await ExecuteLoadCharactersCommand());

            CharacterTapped = new Command<Character>(OnCharacterSelected);
        }

        async Task ExecuteLoadCharactersCommand()
        {
            IsBusy = true;

            try
            {
                Characters.Clear();
                var characters = await Service.GetCharactersAsync();
                foreach (var character in characters)
                {
                    Characters.Add(character);
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