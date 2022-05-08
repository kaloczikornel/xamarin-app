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

        public ObservableCollection<House> Houses { get; }
        public Command LoadHousesCommand { get; }
        public Command AddHouseCommand { get; }
        public Command<House> HouseTapped { get; }
        public HousesViewModel()
        {
            Title = "Houses";
            Houses = new ObservableCollection<House>();
            LoadHousesCommand = new Command(async () => await ExecuteLoadHousesCommand());

            HouseTapped = new Command<House>(OnHouseSelected);
        }

        async Task ExecuteLoadHousesCommand()
        {
            IsBusy = true;

            try
            {
                Houses.Clear();
                var houses = await Service.GetHousesAsync();
                foreach (var house in houses)
                {
                    Houses.Add(house);
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