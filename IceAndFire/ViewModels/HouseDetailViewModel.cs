using IceAndFire.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IceAndFire.ViewModels
{
    [QueryProperty(nameof(HouseId), nameof(HouseId))]
    public class HouseDetailViewModel : BaseViewModel
    {
        private string houseId;
        private string name;
        private string region;
        private string coatOfArms;
        private string words;
        private string titles;
        private string seats;
        private string currentLord;
        private string heir;
        private string overlord;
        private string founded;
        private string founder;
        private string diedOut;
        private string ancestralWeapons;
        private string cadetBranches;
        private string swornMembers;

        public string Id { get; set; }

        public string HouseId
        {
            get
            {
                return houseId;
            }
            set
            {
                houseId = value;
                LoadHouseId(value);
            }
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Region
        {
            get => region;
            set => SetProperty(ref region, value);
        }

        public string CoatOfArms
        {
            get => coatOfArms;
            set => SetProperty(ref coatOfArms, value);
        }
        public string Words
        {
            get => words;
            set => SetProperty(ref words, value);
        }
        public string Titles
        {
            get => titles;
            set => SetProperty(ref titles, value);
        }
        public string Seats
        {
            get => seats;
            set => SetProperty(ref seats, value);
        }
        public string CurrentLord
        {
            get => currentLord;
            set => SetProperty(ref currentLord, value);
        }
        public string Heir
        {
            get => heir;
            set => SetProperty(ref heir, value);
        }
        public string Overlord
        {
            get => overlord;
            set => SetProperty(ref overlord, value);
        }
        public string Founded
        {
            get => founded;
            set => SetProperty(ref founded, value);
        }
        public string Founder
        {
            get => founder;
            set => SetProperty(ref founder, value);
        }
        public string DiedOut
        {
            get => diedOut;
            set => SetProperty(ref diedOut, value);
        }
        public string AncestralWeapons
        {
            get => ancestralWeapons;
            set => SetProperty(ref ancestralWeapons, value);
        }
        public string CadetBranches
        {
            get => cadetBranches;
            set => SetProperty(ref cadetBranches, value);
        }
        public string SwornMembers
        {
            get => swornMembers;
            set => SetProperty(ref swornMembers, value);
        }

        public async void LoadHouseId(string houseId)
        {
            try
            {
                House house = await Service.GetHouseAsync(houseId);
                Name = house.name;
                Region = house.region;
                CoatOfArms = house.coatOfArms;
                Words = house.words;
                var TitlesArray = house.titles;
                Titles = Service.StringArrayToString(TitlesArray);
                var SeatsArray = house.seats;
                Seats = Service.StringArrayToString(SeatsArray);
                CurrentLord = house.currentLord;
                Heir = house.heir;
                Overlord = house.overlord;
                Founded = house.founded;
                Founder = house.founder;
                DiedOut = house.diedOut;
                var AncestralWeaponsArray = house.ancestralWeapons;
                AncestralWeapons = Service.StringArrayToString(AncestralWeaponsArray);
                var CadetBranchesArray = house.cadetBranches;
                CadetBranches = Service.StringArrayToString(CadetBranchesArray);
                var SwornMembersArray = house.swornMembers;
                SwornMembers = Service.StringArrayToString(SwornMembersArray);
                Debug.WriteLine(house.name);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load House");
            }
        }
    }
}
