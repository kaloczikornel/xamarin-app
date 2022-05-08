using IceAndFire.Models;
using IceAndFire.ViewModels;
using IceAndFire.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IceAndFire.Views
{
    public partial class CharactersPage : ContentPage
    {
        CharactersViewModel _viewModel;

        public CharactersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new CharactersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}