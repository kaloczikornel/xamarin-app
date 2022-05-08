using IceAndFire.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace IceAndFire.Views
{
    public partial class CharacterDetailPage : ContentPage
    {
        public CharacterDetailPage()
        {
            InitializeComponent();
            BindingContext = new CharacterDetailViewModel();
        }
    }
}