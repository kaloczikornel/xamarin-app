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
    public class HousesViewModel : BaseViewModel
    {
        private House _selectedHouse;
        public ObservableCollection<House> SearchResults { get; }
        public Command LoadHousesCommand { get; }
        public Command AddHouseCommand { get; }
        public Command<House> HouseTapped { get; }
        public Command<string> PerformSearch { get; }
        public HousesViewModel()
        {
            Title = "Houses";
            SearchResults = new ObservableCollection<House>();
            PerformSearch = new Command<string>(async (string query) => await ExecuteSearch(query));
            HouseTapped = new Command<House>(OnHouseSelected);
        }
        async Task ExecuteSearch(string param)
        {
            Query = param;

            try
            {
                SearchResults.Clear();
                var houses = await Service.GetHouseByNameQueryString(Query);
                foreach (var house in houses)
                {
                    SearchResults.Add(house);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public void OnAppearing()
        {
            SelectedHouse = null;
        }

        public House SelectedHouse
        {
            get => _selectedHouse;
            set
            {
                SetProperty(ref _selectedHouse, value);
                OnHouseSelected(value);
            }
        }

        async void OnHouseSelected(House house)
        {
            
            if (house == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(HouseDetailPage)}?{nameof(HouseDetailViewModel.HouseId)}={house.url}");
            
        }
    }
}